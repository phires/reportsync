using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReportSync.Properties;
using ReportSync.ReportService;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace ReportSync
{
    public partial class ReportSync : Form
    {
        const string RootFolder = "/";
        const string PathSeperator = "/";
        const string SourceSelectionStart = "ReportSyncSource:";
        const string DestSelectionStart = "ReportSyncDest:";
        const string MappingStart = "ReportSyncMap:";

        private ReportingService2005 _sourceRs;
        private ReportingService2005 _destRs;

        private Dictionary<string, string> _sourceDs;
        private Dictionary<string, string> _destDs;

        private string _pathOnDisk;

        private string _uploadPath = RootFolder;
        private List<string> _existingPaths;

        private int _selectedNodeCount;

        private int _processedNodeCount;

        public ReportSync()
        {
            InitializeComponent();
            bwDownload.DoWork += bwDownload_DoWork;
            bwDownload.ProgressChanged += bwDownload_ProgressChanged;
            bwDownload.RunWorkerCompleted += bwDownload_RunWorkerCompleted;

            bwUpload.DoWork += bwUpload_DoWork;
            bwUpload.ProgressChanged +=bwUpload_ProgressChanged;
            bwUpload.RunWorkerCompleted += bwUpload_RunWorkerCompleted;

            bwSync.DoWork += bwSync_DoWork;
            bwSync.ProgressChanged +=bwSync_ProgressChanged;
            bwSync.RunWorkerCompleted += bwSync_RunWorkerCompleted;
        }

        void bwDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
        }

        void bwUpload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbSource.Value = e.ProgressPercentage;
            pbDest.Value = e.ProgressPercentage;
        }

        void bwSync_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UnCheckTreeNodes(rptSourceTree.Nodes);
            LoadDestTree();
            MessageBox.Show(Resources.Sync_completed_successfully, Resources.Sync_complete);
        }

        void bwSync_DoWork(object sender, DoWorkEventArgs e)
        {
            _processedNodeCount = 0;
            var destPath = RootFolder;
            if (!String.IsNullOrEmpty(_uploadPath))
                destPath = _uploadPath;
            SyncTreeNodes(destPath, rptSourceTree.Nodes);
            bwSync.ReportProgress(100);
        }

        void bwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDestTree();
            MessageBox.Show(Resources.Upload_completed_successfully, Resources.Upload_complete);
        }

        void bwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            var files = Directory.GetFiles(txtLocalPath.Text, "*.rdl", SearchOption.AllDirectories);
            _selectedNodeCount = files.Length;
            _processedNodeCount = 0;
            foreach (var file in files)
            {
                var fullPath = file.Replace(txtLocalPath.Text, "").TrimStart('\\');
                var breakAt = fullPath.LastIndexOf('\\');
                var filePath = breakAt == -1 ? String.Empty : fullPath.Substring(0, breakAt).Replace("\\", PathSeperator); 

                var fileName = fullPath.Substring(breakAt + 1, fullPath.Length - 5 - breakAt); //remove the .rdl
                var reportPath = _uploadPath;
                if (reportPath.EndsWith(PathSeperator))
                    reportPath += filePath.TrimStart('/');
                else
                    reportPath += "/" + filePath.TrimStart('/');
                reportPath = reportPath.TrimEnd('/');
                var report = new XmlDocument();
                report.Load(file);
                var reportDef = Encoding.Default.GetBytes(report.OuterXml);
                if (!_existingPaths.Contains(reportPath))
                {
                    EnsureDestDir(reportPath);
                    _existingPaths.Add(reportPath);
                }
                UploadReport(reportPath, fileName, reportDef);
                _processedNodeCount++;
                bwUpload.ReportProgress(_processedNodeCount * 100 / _selectedNodeCount);
            }
            bwUpload.ReportProgress(100);
        }

        void bwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UnCheckTreeNodes(rptSourceTree.Nodes);
            MessageBox.Show(Resources.Report_files_downloaded_successfully, Resources.Download_complete);
        }

        void bwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _processedNodeCount = 0;
                SaveTreeNodes(rptSourceTree.Nodes);
                bwDownload.ReportProgress(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Download_failed + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _sourceRs = new ReportingService2005();
                var reportServerUri = "http://localhost:8080/ReportServer";
                if (!String.IsNullOrEmpty(txtSourceUrl.Text))
                {
                    reportServerUri = txtSourceUrl.Text;
                }

                _sourceRs.Url = reportServerUri + "/ReportService2005.asmx";

                if (!String.IsNullOrEmpty(txtSourceUser.Text))
                {
                    var userName = txtSourceUser.Text;
                    var nameParts = userName.Split('\\', '/');
                    if(nameParts.Length > 2)
                    {
                        MessageBox.Show(Resources.Incorrect_source_user_name, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (nameParts.Length == 2)
                    {
                        userName = nameParts[1];
                        _sourceRs.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text, nameParts[0]);
                    }
                    else
                    {
                        _sourceRs.Credentials = new System.Net.NetworkCredential(userName, txtSourcePassword.Text);
                    }
                }
                else
                {
                    _sourceRs.Credentials = System.Net.CredentialCache.DefaultCredentials;
                }
            
                rptSourceTree.Nodes.Clear();
                _sourceDs = new Dictionary<string, string>();
                LoadTreeNode(RootFolder, rptSourceTree.Nodes, _sourceRs, _sourceDs);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Resources.Loading_failed + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDestLoad_Click(object sender, EventArgs e)
        {
            _destRs = new ReportingService2005();
            var reportServerUri = "http://localhost:8080/ReportServer";
            if (!String.IsNullOrEmpty(txtDestUrl.Text))
            {
                reportServerUri = txtDestUrl.Text;
            }

            _destRs.Url = reportServerUri + "/ReportService2005.asmx";

            if (!String.IsNullOrEmpty(txtDestUser.Text))
            {
                var userName = txtDestUser.Text;
                var nameParts = userName.Split('\\', '/');
                if (nameParts.Length > 2)
                {
                    MessageBox.Show(Resources.Incorrect_destination_user_name,Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nameParts.Length == 2)
                {
                    userName = nameParts[1];
                    _destRs.Credentials = new System.Net.NetworkCredential(userName, txtDestPassword.Text, nameParts[0]);
                }
                else
                {
                    _destRs.Credentials = new System.Net.NetworkCredential(userName, txtDestPassword.Text);
                }             
            }
            else
            {
                _destRs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            try
            {
                LoadDestTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Loading_failed + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void LoadTreeNode(string path, TreeNodeCollection nodes, ReportingService2005 rs, Dictionary<string, string> dataSources)
        {
            var items = rs.ListChildren(path, false);
            foreach (var item in items)
            {
                var t = new TreeNode {Text = item.Name, Name = item.Name};
                if (item.Type == ItemTypeEnum.DataSource)
                {
                    if(!dataSources.ContainsKey(item.Name))
                        dataSources.Add(item.Name, item.Path);
                }
                if (item.Type != ItemTypeEnum.Model && item.Type != ItemTypeEnum.DataSource)
                {    
                    nodes.Add(t);
                }
                if (item.Type == ItemTypeEnum.Folder)
                    LoadTreeNode(item.Path, t.Nodes, rs, dataSources);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _selectedNodeCount = 0;
            CheckTreeNodes(rptSourceTree.Nodes, false);
            bwDownload.RunWorkerAsync();
        }

        private bool CheckTreeNodes(IEnumerable nodes, bool parentChecked)
        {
            var isChecked = parentChecked;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked || parentChecked)
                {
                    CheckTreeNodes(node.Nodes, true);
                    node.Checked = true;
                    node.Tag = true;
                    isChecked = true;
                    _selectedNodeCount++;
                }
                else
                {
                    node.Tag = CheckTreeNodes(node.Nodes, false);
                    isChecked = isChecked || (bool)node.Tag;
                }
            }
            return isChecked;
        }

        private static void UnCheckTreeNodes(IEnumerable nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node != null && node.Tag != null)
                {
                    node.Tag = null;
                }
                if (node != null) UnCheckTreeNodes(node.Nodes);
            }
        }

        private void SaveTreeNodes(IEnumerable nodes)
        {
            foreach (TreeNode node in nodes)
            {
                var destPath = txtLocalPath.Text + "\\" + node.FullPath;
                if (!node.Checked) continue;

                if (node.Nodes.Count > 0)
                {
                    //check if dir exists
                    if (!Directory.Exists(destPath))
                        Directory.CreateDirectory(destPath);
                    SaveTreeNodes(node.Nodes);
                }
                else
                {
                    var itemPath = RootFolder + node.FullPath.Replace("\\", "/");
                    var itemType = _sourceRs.GetItemType(itemPath);
                    if (itemType == ItemTypeEnum.Resource)
                    {
                        //Download the resource
                        string resourceType;
                        var contents = _sourceRs.GetResourceContents(itemPath, out resourceType);
                        File.WriteAllBytes(destPath, contents);
                        continue;
                    }
                    if (itemType == ItemTypeEnum.Report || itemType == ItemTypeEnum.LinkedReport)
                    {
                        var reportDef = _sourceRs.GetReportDefinition(itemPath);
                        var rdl = new XmlDocument();
                        rdl.Load(new MemoryStream(reportDef));
                        rdl.Save(destPath + ".rdl");
                    }
                }
                _processedNodeCount++;
                bwDownload.ReportProgress(_processedNodeCount * 100 / _selectedNodeCount);
            }
        }

        private void LoadDestTree()
        {
            _uploadPath = RootFolder;
            rptDestTree.Nodes.Clear();
            _destDs = new Dictionary<string, string>();
            LoadTreeNode(RootFolder, rptDestTree.Nodes, _destRs, _destDs);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                _selectedNodeCount = 0;
                CheckTreeNodes(rptSourceTree.Nodes, false);
                _existingPaths = new List<string>();
                bwSync.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Sync_failed + Environment.NewLine + ex.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SyncTreeNodes(string destPath, IEnumerable nodes)
        {
            foreach (var node in nodes.Cast<TreeNode>().Where(node => (bool) node.Tag))
            {
                if (node.Nodes.Count > 0)
                {
                    var childPath = destPath;
                    if (node.Checked)
                    {
                        if (destPath.Equals(RootFolder))
                            childPath = RootFolder + node.Text;
                        else
                            childPath = destPath + PathSeperator + node.Text;
                    }
                    SyncTreeNodes(childPath, node.Nodes);
                }
                else
                {
                    if (!_existingPaths.Contains(destPath))
                    {
                        EnsureDestDir(destPath);
                        _existingPaths.Add(destPath);
                    }
                    var itemPath = RootFolder + node.FullPath.Replace("\\", PathSeperator);
                    var itemType = _sourceRs.GetItemType(itemPath);
                    if (itemType == ItemTypeEnum.Resource)
                    {
                        //Download the resource
                        string resourceType;
                        var contents = _sourceRs.GetResourceContents(itemPath, out resourceType);
                        UploadResource(destPath, node.Text, resourceType, contents);
                        _processedNodeCount++;
                        continue;
                    }
                    var reportDef = _sourceRs.GetReportDefinition(itemPath);
                    UploadReport(destPath, node.Text, reportDef);

                    //Sync subscriptions

                    var destReportPath = destPath;
                    if (destReportPath.EndsWith("/"))
                        destReportPath += node.Text;
                    else
                        destReportPath += "/" + node.Text;

                    var subscriptions = _sourceRs.ListSubscriptions(itemPath, txtSourceUser.Text);
                    foreach (var subscription in subscriptions)
                    {
                        ExtensionSettings extSettings;
                        string desc;
                        ActiveState active;
                        string status;
                        string eventType;
                        string matchData;
                        ParameterValue[] values;
                        _sourceRs.GetSubscriptionProperties(subscription.SubscriptionID, out extSettings, out desc, out active, out status, out eventType, out matchData, out values);
                        if (extSettings.Extension == "Report Server FileShare")
                        {
                            var para = new ParameterValue {Name = "PASSWORD", Value = txtDestPassword.Text};
                            var exParams = new ParameterValueOrFieldReference[extSettings.ParameterValues.Length + 1];
                            Array.Copy(extSettings.ParameterValues, exParams, extSettings.ParameterValues.Length);
                            exParams[extSettings.ParameterValues.Length] = para;
                            extSettings.ParameterValues = exParams;
                        }
                        _destRs.CreateSubscription(destReportPath, extSettings, desc, eventType, matchData, values);
                    }

                    _processedNodeCount++;
                    bwSync.ReportProgress(_processedNodeCount * 100 / _selectedNodeCount);
                }
            }
        }

        private void UploadResource(string destinationPath, string resourceName, string resourceType, byte[] contents)
        {
            _destRs.CreateResource(resourceName, destinationPath, true, contents, resourceType, null);
        }

        private void UploadReport(string destinationPath, string reportName, byte[] reportDef)
        {
            try
            {
                //Create report
                _destRs.CreateReport(reportName, destinationPath, true, reportDef, null);

                //Link datasources
                var reportPath = destinationPath;
                if (reportPath.EndsWith("/"))
                    reportPath += reportName;
                else
                    reportPath += "/" + reportName;
                var reportDss = _destRs.GetItemDataSources(reportPath);
                _destRs.SetItemDataSources(reportPath, (from reportDs in reportDss where _destDs.ContainsKey(reportDs.Name) let reference = new DataSourceReference {Reference = _destDs[reportDs.Name]} select new DataSource {Item = reference, Name = reportDs.Name}).ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show(Resources.Upload + reportName + Resources.failed + e.Message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            var result = dlgDest.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLocalPath.Text = dlgDest.SelectedPath;
            }
        }

        private void rptDestTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _uploadPath = RootFolder + e.Node.FullPath.Replace("\\", PathSeperator);
        }

        private void EnsureDestDir(string path)
        { 
            try
            {
                _destRs.ListChildren(path, false);
            }
            catch (Exception)
            { 
                //ensure parent folder
                var breatAt = path.LastIndexOf(PathSeperator, StringComparison.Ordinal);
                var folder = path.Substring(breatAt + 1);
                var parent = path.Substring(0, breatAt);
                if (String.IsNullOrEmpty(parent))
                    parent = RootFolder;
                EnsureDestDir(parent);
                _destRs.CreateFolder(folder,parent, null);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            _existingPaths = new List<string>();
            if (String.IsNullOrEmpty(txtLocalPath.Text))
            {
                MessageBox.Show(Resources.Please_select_the_folder_to_upload);
                return;
            }
            bwUpload.RunWorkerAsync();
        }

        private void ReportSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!chkSaveSource.Checked)
                Settings.Default.SourcePassword = "";
            if (!chkSaveDest.Checked)
                Settings.Default.DestPassword = "";
            Settings.Default.Save();
        }

        private void aboutReportSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutReportSync();
            frmAbout.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mapDataSourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmMapDs = new MapDatasources {SourceDs = _sourceDs, DestDs = _destDs};
            frmMapDs.ShowDialog();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/dapaxx/reportsync");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var res = dlgOpenFile.ShowDialog();
            if (res != DialogResult.OK) return;

            var data = File.ReadAllLines(dlgOpenFile.FileName);
            var stage = 0;
            foreach (var line in data)
            {
                switch (line)
                {
                    case SourceSelectionStart:
                        stage = 1;
                        continue;
                    case DestSelectionStart:
                        stage = 2;
                        continue;
                    case MappingStart:
                        stage = 3;
                        continue;
                }
                switch (stage)
                { 
                    case 1:
                        CheckNodeIfPathExists(rptSourceTree.Nodes, line);
                        break;
                    case 2:
                        CheckNodeIfPathExists(rptDestTree.Nodes, line);
                        break;
                    case 3:
                        var entryParts = line.Split('=');
                        if (entryParts.Length == 2 && _destDs.ContainsKey(entryParts[0]))
                            _destDs[entryParts[0]] = entryParts[1];
                        break;
                }
            }
        }

        static void CheckNodeIfPathExists(TreeNodeCollection nodes, string path)
        {
            var parts = path.Split(new[]{'\\'}, 2);
            var key = parts[0];
            if (!nodes.ContainsKey(key)) return;
            if (parts.Length == 1)
                nodes[key].Checked = true;
            else
            {
                nodes[key].Expand();
                CheckNodeIfPathExists(nodes[key].Nodes, parts[1]);
            }
        }

        private static string SaveCheckedNodes(TreeNodeCollection nodes)
        {
            var data = "";
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                    data += node.FullPath + Environment.NewLine;
                data += SaveCheckedNodes(node.Nodes);
            }
            return data;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPathAndSave();
        }

        void SetPathAndSave()
        {
            var res = dlgSaveFile.ShowDialog();
            if (res != DialogResult.OK) return;
            _pathOnDisk = dlgSaveFile.FileName;
            SaveSelectedNodesToDisk();
        }

        void SaveSelectedNodesToDisk()
        {
            if (!String.IsNullOrEmpty(_pathOnDisk))
            {
                // save tree to disk
                var data = SourceSelectionStart + Environment.NewLine;
                data += SaveCheckedNodes(rptSourceTree.Nodes);
                data += DestSelectionStart + Environment.NewLine;
                data += SaveCheckedNodes(rptDestTree.Nodes);
                data += MappingStart + Environment.NewLine;
                //save mapping
                data = _destDs.Aggregate(data, (current, entry) => current + (entry.Key + "=" + entry.Value + Environment.NewLine));
                File.WriteAllText(_pathOnDisk, data);
            }
            else
            {
                SetPathAndSave();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSelectedNodesToDisk();
        }
    }
}
