namespace ReportSync
{
    partial class ReportSync
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportSync));
            this.dlgDest = new System.Windows.Forms.FolderBrowserDialog();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.bwUpload = new System.ComponentModel.BackgroundWorker();
            this.bwSync = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapDataSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutReportSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.bottomStrip = new System.Windows.Forms.StatusStrip();
            this.currentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.lblDest = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnDest = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.rptSourceTree = new System.Windows.Forms.TreeView();
            this.panelSource = new System.Windows.Forms.Panel();
            this.btnSourceLoad = new System.Windows.Forms.Button();
            this.tabSourceSettings = new System.Windows.Forms.TabControl();
            this.tabSourceAuth = new System.Windows.Forms.TabPage();
            this.cbSourceIntegratedAuth = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSourcePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSourceUser = new System.Windows.Forms.TextBox();
            this.tabSourceStatus = new System.Windows.Forms.TabPage();
            this.lbSourceStatus = new System.Windows.Forms.Label();
            this.lblSrcUrl = new System.Windows.Forms.Label();
            this.chkSaveSource = new System.Windows.Forms.CheckBox();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.pbSource = new System.Windows.Forms.ProgressBar();
            this.grpDest = new System.Windows.Forms.GroupBox();
            this.rptDestTree = new System.Windows.Forms.TreeView();
            this.pnlDestSettings = new System.Windows.Forms.Panel();
            this.tabDestSettings = new System.Windows.Forms.TabControl();
            this.tabDestAuth = new System.Windows.Forms.TabPage();
            this.cbDestIntegratedAuth = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDestPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDestUser = new System.Windows.Forms.TextBox();
            this.tabDestStatus = new System.Windows.Forms.TabPage();
            this.lbDestStatus = new System.Windows.Forms.Label();
            this.lblDestUrl = new System.Windows.Forms.Label();
            this.chkSaveDest = new System.Windows.Forms.CheckBox();
            this.btnDestLoad = new System.Windows.Forms.Button();
            this.txtDestUrl = new System.Windows.Forms.TextBox();
            this.pbDest = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.bottomStrip.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpSource.SuspendLayout();
            this.panelSource.SuspendLayout();
            this.tabSourceSettings.SuspendLayout();
            this.tabSourceAuth.SuspendLayout();
            this.tabSourceStatus.SuspendLayout();
            this.grpDest.SuspendLayout();
            this.pnlDestSettings.SuspendLayout();
            this.tabDestSettings.SuspendLayout();
            this.tabDestAuth.SuspendLayout();
            this.tabDestStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwDownload
            // 
            this.bwDownload.WorkerReportsProgress = true;
            // 
            // bwUpload
            // 
            this.bwUpload.WorkerReportsProgress = true;
            // 
            // bwSync
            // 
            this.bwSync.WorkerReportsProgress = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapDataSourcesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mapDataSourcesToolStripMenuItem
            // 
            this.mapDataSourcesToolStripMenuItem.Name = "mapDataSourcesToolStripMenuItem";
            this.mapDataSourcesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.mapDataSourcesToolStripMenuItem.Text = "Map DataSources";
            this.mapDataSourcesToolStripMenuItem.Click += new System.EventHandler(this.mapDataSourcesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.aboutReportSyncToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.contentsToolStripMenuItem.Text = "Contents (Online)";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // aboutReportSyncToolStripMenuItem
            // 
            this.aboutReportSyncToolStripMenuItem.Name = "aboutReportSyncToolStripMenuItem";
            this.aboutReportSyncToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.aboutReportSyncToolStripMenuItem.Text = "About ReportSync";
            this.aboutReportSyncToolStripMenuItem.Click += new System.EventHandler(this.aboutReportSyncToolStripMenuItem_Click);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.FileName = "ReportSync.rsn";
            this.dlgSaveFile.Filter = "ReportSync Files | *.rsn";
            this.dlgSaveFile.Title = "Save ReportSync selection";
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "ReportSync.rsn";
            this.dlgOpenFile.Filter = "ReportSync Files | *.rsn";
            this.dlgOpenFile.Title = "Open ReportSync file";
            // 
            // bottomStrip
            // 
            this.bottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatus});
            this.bottomStrip.Location = new System.Drawing.Point(0, 451);
            this.bottomStrip.Name = "bottomStrip";
            this.bottomStrip.Size = new System.Drawing.Size(758, 22);
            this.bottomStrip.TabIndex = 25;
            this.bottomStrip.Text = "statusStrip1";
            // 
            // currentStatus
            // 
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanel.Controls.Add(this.btnUpload);
            this.bottomPanel.Controls.Add(this.txtLocalPath);
            this.bottomPanel.Controls.Add(this.lblDest);
            this.bottomPanel.Controls.Add(this.btnDownload);
            this.bottomPanel.Controls.Add(this.btnSync);
            this.bottomPanel.Controls.Add(this.btnDest);
            this.bottomPanel.Location = new System.Drawing.Point(0, 418);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(758, 36);
            this.bottomPanel.TabIndex = 22;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(378, 6);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(55, 21);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "LocalPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLocalPath.Location = new System.Drawing.Point(68, 6);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(197, 20);
            this.txtLocalPath.TabIndex = 5;
            this.txtLocalPath.Text = global::ReportSync.Properties.Settings.Default.LocalPath;
            // 
            // lblDest
            // 
            this.lblDest.AutoSize = true;
            this.lblDest.Location = new System.Drawing.Point(7, 9);
            this.lblDest.Name = "lblDest";
            this.lblDest.Size = new System.Drawing.Size(57, 13);
            this.lblDest.TabIndex = 21;
            this.lblDest.Text = "Local path";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(307, 6);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(65, 21);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(439, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(41, 21);
            this.btnSync.TabIndex = 13;
            this.btnSync.Text = "&Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(274, 6);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(24, 21);
            this.btnDest.TabIndex = 6;
            this.btnDest.Text = "...";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSource);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpDest);
            this.splitContainer1.Size = new System.Drawing.Size(758, 388);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 28;
            // 
            // grpSource
            // 
            this.grpSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSource.Controls.Add(this.rptSourceTree);
            this.grpSource.Controls.Add(this.panelSource);
            this.grpSource.Controls.Add(this.pbSource);
            this.grpSource.Location = new System.Drawing.Point(3, 3);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(373, 382);
            this.grpSource.TabIndex = 30;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source SSRS web service";
            // 
            // rptSourceTree
            // 
            this.rptSourceTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptSourceTree.CheckBoxes = true;
            this.rptSourceTree.Location = new System.Drawing.Point(12, 205);
            this.rptSourceTree.Name = "rptSourceTree";
            this.rptSourceTree.Size = new System.Drawing.Size(348, 145);
            this.rptSourceTree.TabIndex = 5;
            this.rptSourceTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rptSourceTree_AfterCheck);
            this.rptSourceTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.rptSourceTree_AfterExpand);
            // 
            // panelSource
            // 
            this.panelSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSource.Controls.Add(this.btnSourceLoad);
            this.panelSource.Controls.Add(this.tabSourceSettings);
            this.panelSource.Controls.Add(this.lblSrcUrl);
            this.panelSource.Controls.Add(this.chkSaveSource);
            this.panelSource.Controls.Add(this.txtSourceUrl);
            this.panelSource.Location = new System.Drawing.Point(4, 16);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(358, 183);
            this.panelSource.TabIndex = 23;
            // 
            // btnSourceLoad
            // 
            this.btnSourceLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSourceLoad.Location = new System.Drawing.Point(300, 160);
            this.btnSourceLoad.Name = "btnSourceLoad";
            this.btnSourceLoad.Size = new System.Drawing.Size(55, 20);
            this.btnSourceLoad.TabIndex = 24;
            this.btnSourceLoad.Text = "Load";
            this.btnSourceLoad.UseVisualStyleBackColor = true;
            this.btnSourceLoad.Click += new System.EventHandler(this.btnSourceLoad_Click);
            // 
            // tabSourceSettings
            // 
            this.tabSourceSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSourceSettings.Controls.Add(this.tabSourceAuth);
            this.tabSourceSettings.Controls.Add(this.tabSourceStatus);
            this.tabSourceSettings.Location = new System.Drawing.Point(3, 30);
            this.tabSourceSettings.Name = "tabSourceSettings";
            this.tabSourceSettings.SelectedIndex = 0;
            this.tabSourceSettings.Size = new System.Drawing.Size(352, 123);
            this.tabSourceSettings.TabIndex = 23;
            // 
            // tabSourceAuth
            // 
            this.tabSourceAuth.Controls.Add(this.cbSourceIntegratedAuth);
            this.tabSourceAuth.Controls.Add(this.label2);
            this.tabSourceAuth.Controls.Add(this.tbSourcePassword);
            this.tabSourceAuth.Controls.Add(this.label1);
            this.tabSourceAuth.Controls.Add(this.tbSourceUser);
            this.tabSourceAuth.Location = new System.Drawing.Point(4, 22);
            this.tabSourceAuth.Name = "tabSourceAuth";
            this.tabSourceAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabSourceAuth.Size = new System.Drawing.Size(344, 97);
            this.tabSourceAuth.TabIndex = 0;
            this.tabSourceAuth.Text = "Authentication";
            this.tabSourceAuth.UseVisualStyleBackColor = true;
            // 
            // cbSourceIntegratedAuth
            // 
            this.cbSourceIntegratedAuth.AutoSize = true;
            this.cbSourceIntegratedAuth.Location = new System.Drawing.Point(9, 53);
            this.cbSourceIntegratedAuth.Name = "cbSourceIntegratedAuth";
            this.cbSourceIntegratedAuth.Size = new System.Drawing.Size(164, 17);
            this.cbSourceIntegratedAuth.TabIndex = 26;
            this.cbSourceIntegratedAuth.Text = "Use Integated Authentication";
            this.cbSourceIntegratedAuth.UseVisualStyleBackColor = true;
            this.cbSourceIntegratedAuth.CheckedChanged += new System.EventHandler(this.cbSourceIntegratedAuth_CheckedChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Password";
            // 
            // tbSourcePassword
            // 
            this.tbSourcePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourcePassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSourcePassword.Location = new System.Drawing.Point(77, 27);
            this.tbSourcePassword.Name = "tbSourcePassword";
            this.tbSourcePassword.PasswordChar = '*';
            this.tbSourcePassword.Size = new System.Drawing.Size(260, 20);
            this.tbSourcePassword.TabIndex = 23;
            this.tbSourcePassword.Text = global::ReportSync.Properties.Settings.Default.SourcePassword;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "User";
            // 
            // tbSourceUser
            // 
            this.tbSourceUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourceUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbSourceUser.Location = new System.Drawing.Point(77, 4);
            this.tbSourceUser.Name = "tbSourceUser";
            this.tbSourceUser.Size = new System.Drawing.Size(260, 20);
            this.tbSourceUser.TabIndex = 22;
            this.tbSourceUser.Text = global::ReportSync.Properties.Settings.Default.SourceUser;
            // 
            // tabSourceStatus
            // 
            this.tabSourceStatus.Controls.Add(this.lbSourceStatus);
            this.tabSourceStatus.Location = new System.Drawing.Point(4, 22);
            this.tabSourceStatus.Name = "tabSourceStatus";
            this.tabSourceStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabSourceStatus.Size = new System.Drawing.Size(344, 97);
            this.tabSourceStatus.TabIndex = 1;
            this.tabSourceStatus.Text = "Status";
            this.tabSourceStatus.UseVisualStyleBackColor = true;
            // 
            // lbSourceStatus
            // 
            this.lbSourceStatus.Location = new System.Drawing.Point(7, 7);
            this.lbSourceStatus.Name = "lbSourceStatus";
            this.lbSourceStatus.Size = new System.Drawing.Size(331, 87);
            this.lbSourceStatus.TabIndex = 0;
            // 
            // lblSrcUrl
            // 
            this.lblSrcUrl.AutoSize = true;
            this.lblSrcUrl.Location = new System.Drawing.Point(6, 7);
            this.lblSrcUrl.Name = "lblSrcUrl";
            this.lblSrcUrl.Size = new System.Drawing.Size(20, 13);
            this.lblSrcUrl.TabIndex = 19;
            this.lblSrcUrl.Text = "Url";
            // 
            // chkSaveSource
            // 
            this.chkSaveSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveSource.AutoSize = true;
            this.chkSaveSource.Checked = true;
            this.chkSaveSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveSource.Location = new System.Drawing.Point(243, 163);
            this.chkSaveSource.Name = "chkSaveSource";
            this.chkSaveSource.Size = new System.Drawing.Size(51, 17);
            this.chkSaveSource.TabIndex = 22;
            this.chkSaveSource.Text = "Save";
            this.chkSaveSource.UseVisualStyleBackColor = true;
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSourceUrl.Location = new System.Drawing.Point(35, 4);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(315, 20);
            this.txtSourceUrl.TabIndex = 1;
            this.txtSourceUrl.Text = global::ReportSync.Properties.Settings.Default.SourceUrl;
            // 
            // pbSource
            // 
            this.pbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSource.Location = new System.Drawing.Point(10, 354);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(350, 23);
            this.pbSource.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSource.TabIndex = 22;
            // 
            // grpDest
            // 
            this.grpDest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDest.Controls.Add(this.rptDestTree);
            this.grpDest.Controls.Add(this.pnlDestSettings);
            this.grpDest.Controls.Add(this.pbDest);
            this.grpDest.Location = new System.Drawing.Point(3, 3);
            this.grpDest.Name = "grpDest";
            this.grpDest.Size = new System.Drawing.Size(365, 382);
            this.grpDest.TabIndex = 27;
            this.grpDest.TabStop = false;
            this.grpDest.Text = "Destination SSRS web service";
            // 
            // rptDestTree
            // 
            this.rptDestTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptDestTree.CheckBoxes = true;
            this.rptDestTree.Location = new System.Drawing.Point(3, 205);
            this.rptDestTree.Name = "rptDestTree";
            this.rptDestTree.Size = new System.Drawing.Size(353, 145);
            this.rptDestTree.TabIndex = 13;
            this.rptDestTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.rptDestTree_AfterCheck);
            this.rptDestTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.rptDestTree_AfterExpand);
            this.rptDestTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.rptDestTree_NodeMouseClick);
            // 
            // pnlDestSettings
            // 
            this.pnlDestSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDestSettings.Controls.Add(this.tabDestSettings);
            this.pnlDestSettings.Controls.Add(this.lblDestUrl);
            this.pnlDestSettings.Controls.Add(this.chkSaveDest);
            this.pnlDestSettings.Controls.Add(this.btnDestLoad);
            this.pnlDestSettings.Controls.Add(this.txtDestUrl);
            this.pnlDestSettings.Location = new System.Drawing.Point(3, 16);
            this.pnlDestSettings.Name = "pnlDestSettings";
            this.pnlDestSettings.Size = new System.Drawing.Size(353, 183);
            this.pnlDestSettings.TabIndex = 24;
            // 
            // tabDestSettings
            // 
            this.tabDestSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDestSettings.Controls.Add(this.tabDestAuth);
            this.tabDestSettings.Controls.Add(this.tabDestStatus);
            this.tabDestSettings.Location = new System.Drawing.Point(3, 30);
            this.tabDestSettings.Name = "tabDestSettings";
            this.tabDestSettings.SelectedIndex = 0;
            this.tabDestSettings.Size = new System.Drawing.Size(344, 123);
            this.tabDestSettings.TabIndex = 24;
            // 
            // tabDestAuth
            // 
            this.tabDestAuth.Controls.Add(this.cbDestIntegratedAuth);
            this.tabDestAuth.Controls.Add(this.label3);
            this.tabDestAuth.Controls.Add(this.tbDestPassword);
            this.tabDestAuth.Controls.Add(this.label4);
            this.tabDestAuth.Controls.Add(this.tbDestUser);
            this.tabDestAuth.Location = new System.Drawing.Point(4, 22);
            this.tabDestAuth.Name = "tabDestAuth";
            this.tabDestAuth.Padding = new System.Windows.Forms.Padding(3);
            this.tabDestAuth.Size = new System.Drawing.Size(336, 97);
            this.tabDestAuth.TabIndex = 0;
            this.tabDestAuth.Text = "Authentication";
            this.tabDestAuth.UseVisualStyleBackColor = true;
            // 
            // cbDestIntegratedAuth
            // 
            this.cbDestIntegratedAuth.AutoSize = true;
            this.cbDestIntegratedAuth.Location = new System.Drawing.Point(9, 53);
            this.cbDestIntegratedAuth.Name = "cbDestIntegratedAuth";
            this.cbDestIntegratedAuth.Size = new System.Drawing.Size(164, 17);
            this.cbDestIntegratedAuth.TabIndex = 26;
            this.cbDestIntegratedAuth.Text = "Use Integated Authentication";
            this.cbDestIntegratedAuth.UseVisualStyleBackColor = true;
            this.cbDestIntegratedAuth.CheckedChanged += new System.EventHandler(this.cbDestIntegratedAuth_CheckedChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Password";
            // 
            // tbDestPassword
            // 
            this.tbDestPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourcePassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDestPassword.Location = new System.Drawing.Point(77, 27);
            this.tbDestPassword.Name = "tbDestPassword";
            this.tbDestPassword.PasswordChar = '*';
            this.tbDestPassword.Size = new System.Drawing.Size(252, 20);
            this.tbDestPassword.TabIndex = 23;
            this.tbDestPassword.Text = global::ReportSync.Properties.Settings.Default.SourcePassword;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "User";
            // 
            // tbDestUser
            // 
            this.tbDestUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "SourceUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbDestUser.Location = new System.Drawing.Point(77, 4);
            this.tbDestUser.Name = "tbDestUser";
            this.tbDestUser.Size = new System.Drawing.Size(252, 20);
            this.tbDestUser.TabIndex = 22;
            this.tbDestUser.Text = global::ReportSync.Properties.Settings.Default.SourceUser;
            // 
            // tabDestStatus
            // 
            this.tabDestStatus.Controls.Add(this.lbDestStatus);
            this.tabDestStatus.Location = new System.Drawing.Point(4, 22);
            this.tabDestStatus.Name = "tabDestStatus";
            this.tabDestStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabDestStatus.Size = new System.Drawing.Size(336, 97);
            this.tabDestStatus.TabIndex = 1;
            this.tabDestStatus.Text = "Status";
            this.tabDestStatus.UseVisualStyleBackColor = true;
            // 
            // lbDestStatus
            // 
            this.lbDestStatus.Location = new System.Drawing.Point(3, 7);
            this.lbDestStatus.Name = "lbDestStatus";
            this.lbDestStatus.Size = new System.Drawing.Size(328, 94);
            this.lbDestStatus.TabIndex = 0;
            // 
            // lblDestUrl
            // 
            this.lblDestUrl.AutoSize = true;
            this.lblDestUrl.Location = new System.Drawing.Point(3, 7);
            this.lblDestUrl.Name = "lblDestUrl";
            this.lblDestUrl.Size = new System.Drawing.Size(20, 13);
            this.lblDestUrl.TabIndex = 18;
            this.lblDestUrl.Text = "Url";
            // 
            // chkSaveDest
            // 
            this.chkSaveDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveDest.AutoSize = true;
            this.chkSaveDest.Checked = true;
            this.chkSaveDest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDest.Location = new System.Drawing.Point(233, 163);
            this.chkSaveDest.Name = "chkSaveDest";
            this.chkSaveDest.Size = new System.Drawing.Size(51, 17);
            this.chkSaveDest.TabIndex = 22;
            this.chkSaveDest.Text = "Save";
            this.chkSaveDest.UseVisualStyleBackColor = true;
            // 
            // btnDestLoad
            // 
            this.btnDestLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestLoad.Location = new System.Drawing.Point(290, 160);
            this.btnDestLoad.Name = "btnDestLoad";
            this.btnDestLoad.Size = new System.Drawing.Size(57, 20);
            this.btnDestLoad.TabIndex = 11;
            this.btnDestLoad.Text = "Load";
            this.btnDestLoad.UseVisualStyleBackColor = true;
            this.btnDestLoad.Click += new System.EventHandler(this.btnDestLoad_Click);
            // 
            // txtDestUrl
            // 
            this.txtDestUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReportSync.Properties.Settings.Default, "DestUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDestUrl.Location = new System.Drawing.Point(27, 4);
            this.txtDestUrl.Name = "txtDestUrl";
            this.txtDestUrl.Size = new System.Drawing.Size(320, 20);
            this.txtDestUrl.TabIndex = 8;
            this.txtDestUrl.Text = global::ReportSync.Properties.Settings.Default.DestUrl;
            // 
            // pbDest
            // 
            this.pbDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDest.Location = new System.Drawing.Point(3, 354);
            this.pbDest.Name = "pbDest";
            this.pbDest.Size = new System.Drawing.Size(353, 23);
            this.pbDest.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDest.TabIndex = 23;
            // 
            // ReportSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 473);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.bottomStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReportSync";
            this.Text = "ReportSync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportSync_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.bottomStrip.ResumeLayout(false);
            this.bottomStrip.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpSource.ResumeLayout(false);
            this.panelSource.ResumeLayout(false);
            this.panelSource.PerformLayout();
            this.tabSourceSettings.ResumeLayout(false);
            this.tabSourceAuth.ResumeLayout(false);
            this.tabSourceAuth.PerformLayout();
            this.tabSourceStatus.ResumeLayout(false);
            this.grpDest.ResumeLayout(false);
            this.pnlDestSettings.ResumeLayout(false);
            this.pnlDestSettings.PerformLayout();
            this.tabDestSettings.ResumeLayout(false);
            this.tabDestAuth.ResumeLayout(false);
            this.tabDestAuth.PerformLayout();
            this.tabDestStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog dlgDest;
        private System.ComponentModel.BackgroundWorker bwDownload;
        private System.ComponentModel.BackgroundWorker bwUpload;
        private System.ComponentModel.BackgroundWorker bwSync;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutReportSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapDataSourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.StatusStrip bottomStrip;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Label lblDest;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnDest;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.TreeView rptSourceTree;
        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Button btnSourceLoad;
        private System.Windows.Forms.TabControl tabSourceSettings;
        private System.Windows.Forms.TabPage tabSourceAuth;
        private System.Windows.Forms.CheckBox cbSourceIntegratedAuth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSourcePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSourceUser;
        private System.Windows.Forms.TabPage tabSourceStatus;
        private System.Windows.Forms.Label lblSrcUrl;
        private System.Windows.Forms.CheckBox chkSaveSource;
        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.ProgressBar pbSource;
        private System.Windows.Forms.GroupBox grpDest;
        private System.Windows.Forms.TreeView rptDestTree;
        private System.Windows.Forms.Panel pnlDestSettings;
        private System.Windows.Forms.Label lblDestUrl;
        private System.Windows.Forms.CheckBox chkSaveDest;
        private System.Windows.Forms.Button btnDestLoad;
        private System.Windows.Forms.TextBox txtDestUrl;
        private System.Windows.Forms.ProgressBar pbDest;
        private System.Windows.Forms.TabControl tabDestSettings;
        private System.Windows.Forms.TabPage tabDestAuth;
        private System.Windows.Forms.CheckBox cbDestIntegratedAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDestPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDestUser;
        private System.Windows.Forms.TabPage tabDestStatus;
        private System.Windows.Forms.ToolStripStatusLabel currentStatus;
        private System.Windows.Forms.Label lbSourceStatus;
        private System.Windows.Forms.Label lbDestStatus;
    }
}

