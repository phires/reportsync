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

        private ReportingServicesMgmt _destServicesMgmt;
        private ReportingServicesMgmt _sourceServicesMgmt;

        private string _pathOnDisk;

        private string _uploadPath = RootFolder;
        private List<string> _existingPaths;

        private int _selectedNodeCount;
        private int _processedNodeCount;

        private int _countFolderSource;
        private int _countReportsSource;
        
        private int _countFolderDest;
        private int _countReportsDest;


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
            //LoadDestTree();
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
            //LoadDestTree();
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
       
        private void btnSourceLoad_Click(object sender, EventArgs e)
        {
            if (txtSourceUrl.TextLength < 2)
            {
                MessageBox.Show("The url cannot be blank\nURL must look like:\nhttp://<reportURLorIP>/ReportServerSQL", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var stopLoad = new Stopwatch();
            stopLoad.Start();
            currentStatus.Text = Resources.Getting_reports__please_wait;
            grpSource.Enabled = false;
            tabSourceSettings.SelectTab("tabSourceStatus");
            _countFolderSource = _countReportsSource = 0;
            Application.DoEvents();
            _sourceServicesMgmt = cbSourceIntegratedAuth.Checked ? new ReportingServicesMgmt(txtSourceUrl.Text, null, null, true) : new ReportingServicesMgmt(txtSourceUrl.Text, tbSourceUser.Text, tbSourcePassword.Text, true);
            rptSourceTree.Nodes.Clear();
            rptSourceTree.BeginUpdate();
            LoadTreeNode(RootFolder, rptSourceTree.Nodes, _sourceServicesMgmt.ReportingService, true);
            rptSourceTree.EndUpdate();
            currentStatus.Text = String.Empty;
            grpSource.Enabled = true;
            stopLoad.Stop();
            lbSourceStatus.Text += Environment.NewLine + String.Format("Process took {0}", stopLoad.Elapsed);
        }

        private void btnDestLoad_Click(object sender, EventArgs e)
        {
            currentStatus.Text = Resources.Getting_reports__please_wait;
            grpDest.Enabled = false;
            Application.DoEvents();
            _destServicesMgmt = cbDestIntegratedAuth.Checked ? new ReportingServicesMgmt(txtDestUrl.Text, null, null, true) : new ReportingServicesMgmt(txtDestUrl.Text, tbDestUser.Text, tbDestPassword.Text, true);
            rptDestTree.Nodes.Clear();
            rptDestTree.BeginUpdate();
            LoadTreeNode(RootFolder, rptDestTree.Nodes, _destServicesMgmt.ReportingService);
            rptDestTree.EndUpdate();
            currentStatus.Text = String.Empty;
            grpDest.Enabled = true;
        }

        private void LoadTreeNode(string path, TreeNodeCollection nodes, ReportingService2005 rs, bool source = false)
        {
            CatalogItem[] items;
            try
            {
                items = rs.ListChildren(path, false);
            }
            catch
            {
                return;
            }
            
            foreach (var item in items)
            {
                if(source)
                    lbSourceStatus.Text = String.Format("Source contains:{0} {1} reports{0} {2} folders{0} {3} datasources", Environment.NewLine,
                        _countReportsSource, _countFolderSource, _sourceServicesMgmt.DataSources.Count);
                else
                    lbDestStatus.Text = String.Format("Destination contains:{0} {1} reports{0} {2} folders{0} {3} datasources", Environment.NewLine,
                        _countReportsDest, _countFolderDest, _destServicesMgmt.DataSources.Count);

                Application.DoEvents();
                var t = new TreeNode { Text = item.Name, Name = item.Name };

                if (item.Type == ItemTypeEnum.DataSource)
                {
                    if (source)
                    {
                        if (!_sourceServicesMgmt.DataSources.ContainsKey(item.Name))
                            _sourceServicesMgmt.DataSources.Add(item.Name, item.Path);
                    }
                    else
                    {
                        if (!_destServicesMgmt.DataSources.ContainsKey(item.Name))
                            _destServicesMgmt.DataSources.Add(item.Name, item.Path);
                    }
                }

                if (item.Type != ItemTypeEnum.Model && item.Type != ItemTypeEnum.DataSource)
                {
                    nodes.Add(t);
                    if (source) _countReportsSource++;
                    else _countReportsDest++;
                }

                if (item.Type == ItemTypeEnum.Folder)
                {
                    // Adds a "dummy" child node to flag that this node needs to be filled. The nodes are filled whenever
                    // they are expanded or checked.
                    t.Nodes.Add(new LoadingTreeNode(item.Path));

                    if (source) _countFolderSource++;
                    else _countFolderDest++;
                }
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
                    var itemType = _sourceServicesMgmt.ReportingService.GetItemType(itemPath);
                    if (itemType == ItemTypeEnum.Resource)
                    {
                        //Download the resource
                        string resourceType;
                        var contents = _sourceServicesMgmt.ReportingService.GetResourceContents(itemPath, out resourceType);
                        File.WriteAllBytes(destPath, contents);
                        continue;
                    }
                    if (itemType == ItemTypeEnum.Report || itemType == ItemTypeEnum.LinkedReport)
                    {
                        var reportDef = _sourceServicesMgmt.ReportingService.GetReportDefinition(itemPath);
                        var rdl = new XmlDocument();
                        rdl.Load(new MemoryStream(reportDef));
                        rdl.Save(destPath + ".rdl");
                    }
                }
                _processedNodeCount++;
                bwDownload.ReportProgress(_processedNodeCount * 100 / _selectedNodeCount);
            }
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
                    var itemType = _sourceServicesMgmt.ReportingService.GetItemType(itemPath);
                    if (itemType == ItemTypeEnum.Resource)
                    {
                        //Download the resource
                        string resourceType;
                        var contents = _sourceServicesMgmt.ReportingService.GetResourceContents(itemPath, out resourceType);
                        UploadResource(destPath, node.Text, resourceType, contents);
                        _processedNodeCount++;
                        continue;
                    }
                    var reportDef = _sourceServicesMgmt.ReportingService.GetReportDefinition(itemPath);
                    UploadReport(destPath, node.Text, reportDef);

                    //Sync subscriptions

                    var destReportPath = destPath;
                    if (destReportPath.EndsWith("/"))
                        destReportPath += node.Text;
                    else
                        destReportPath += "/" + node.Text;

                    var subscriptions = _sourceServicesMgmt.ReportingService.ListSubscriptions(itemPath, tbSourceUser.Text);
                    foreach (var subscription in subscriptions)
                    {
                        ExtensionSettings extSettings;
                        string desc;
                        ActiveState active;
                        string status;
                        string eventType;
                        string matchData;
                        ParameterValue[] values;
                        _sourceServicesMgmt.ReportingService.GetSubscriptionProperties(subscription.SubscriptionID, out extSettings, out desc, out active, out status, out eventType, out matchData, out values);
                        if (extSettings.Extension == "Report Server FileShare")
                        {
                            var para = new ParameterValue {Name = "PASSWORD", Value = tbDestPassword.Text};
                            var exParams = new ParameterValueOrFieldReference[extSettings.ParameterValues.Length + 1];
                            Array.Copy(extSettings.ParameterValues, exParams, extSettings.ParameterValues.Length);
                            exParams[extSettings.ParameterValues.Length] = para;
                            extSettings.ParameterValues = exParams;
                        }
                        _destServicesMgmt.ReportingService.CreateSubscription(destReportPath, extSettings, desc, eventType, matchData, values);
                    }

                    _processedNodeCount++;
                    bwSync.ReportProgress(_processedNodeCount * 100 / _selectedNodeCount);
                }
            }
        }

        private void UploadResource(string destinationPath, string resourceName, string resourceType, byte[] contents)
        {
            _destServicesMgmt.ReportingService.CreateResource(resourceName, destinationPath, true, contents, resourceType, null);
        }

        private void UploadReport(string destinationPath, string reportName, byte[] reportDef)
        {
            try
            {
                //Create report
                _destServicesMgmt.ReportingService.CreateReport(reportName, destinationPath, true, reportDef, null);

                //Link datasources
                var reportPath = destinationPath;
                if (reportPath.EndsWith("/"))
                    reportPath += reportName;
                else
                    reportPath += "/" + reportName;
                var reportDss = _destServicesMgmt.ReportingService.GetItemDataSources(reportPath);
                _destServicesMgmt.ReportingService.SetItemDataSources(reportPath, (from reportDs in reportDss where _destServicesMgmt.DataSources.ContainsKey(reportDs.Name) let reference = new DataSourceReference { Reference = _destServicesMgmt.DataSources[reportDs.Name] } select new DataSource { Item = reference, Name = reportDs.Name }).ToArray());
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
                _destServicesMgmt.ReportingService.ListChildren(path, false);
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
                _destServicesMgmt.ReportingService.CreateFolder(folder, parent, null);
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
            if (_sourceServicesMgmt == null || _destServicesMgmt == null)
            {
                MessageBox.Show(Resources.Please_load_reports_from_both_source_and_destination_server, Resources.Error,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var frmMapDs = new MapDatasources { SourceDs = _sourceServicesMgmt.DataSources, DestDs = _destServicesMgmt.DataSources };
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
                        if (entryParts.Length == 2 && _destServicesMgmt.DataSources.ContainsKey(entryParts[0]))
                            _destServicesMgmt.DataSources[entryParts[0]] = entryParts[1];
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
                data = _destServicesMgmt.DataSources.Aggregate(data, (current, entry) => current + (entry.Key + "=" + entry.Value + Environment.NewLine));
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

       
        private void cbDestIntegratedAuth_CheckedChanged_1(object sender, EventArgs e)
        {
            tbDestUser.Enabled = tbDestPassword.Enabled = !cbDestIntegratedAuth.Checked;
        }

        private void cbSourceIntegratedAuth_CheckedChanged_1(object sender, EventArgs e)
        {
            tbSourceUser.Enabled = tbSourcePassword.Enabled = !cbSourceIntegratedAuth.Checked;
        }

        private void rptSourceTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            DoWithDisabledUI(() => EnsureChildNodesAreLoaded(e.Node, _sourceServicesMgmt.ReportingService, true));
        }

        private void rptSourceTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                DoWithDisabledUI(() => EnsureDescendantNodesAreLoaded(e.Node, _sourceServicesMgmt.ReportingService, true));
            }
        }

        private void rptDestTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            DoWithDisabledUI(() => EnsureChildNodesAreLoaded(e.Node, _destServicesMgmt.ReportingService, false));
        }

        private void rptDestTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                DoWithDisabledUI(() => EnsureDescendantNodesAreLoaded(e.Node, _destServicesMgmt.ReportingService, false));
            }
        }

        private void EnsureDescendantNodesAreLoaded(TreeNode parentNode, ReportingService2005 reportingService, bool source)
        {
            if (!EnsureChildNodesAreLoaded(parentNode, reportingService, source))
            {
                return;
            }

            foreach (TreeNode childNode in parentNode.Nodes)
            {
                EnsureDescendantNodesAreLoaded(childNode, reportingService, source);
            }
        }

        private bool EnsureChildNodesAreLoaded(TreeNode parentNode, ReportingService2005 reportingService, bool source)
        {
            LoadingTreeNode loadingTreeNode;
            if (LoadingTreeNode.TryGetLoadingNode(parentNode, out loadingTreeNode))
            {
                parentNode.Nodes.Clear();
                LoadTreeNode(loadingTreeNode.SsrsPath, parentNode.Nodes, reportingService, source);

                return true;
            }

            return false;
        }

        // Since Application.DoEvents is being used, there are many actions that we don't want the user to interrupt.
        // This makes sure the user doesn't click on something while we are processing.
        private void DoWithDisabledUI(Action action)
        {
            if (this.Enabled)
            {
                this.Enabled = false;
                try
                {
                    action();
                }
                finally
                {
                    this.Enabled = true;
                }
            }
            else
            {
                action();
            }
        }
    }
}
