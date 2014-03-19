namespace ReportSync
{
    partial class MapDatasources
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
            this.dataSourcesGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.Button();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourcesGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataSourcesGrid
            // 
            this.dataSourcesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSourcesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Destination,
            this.Value});
            this.dataSourcesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourcesGrid.Location = new System.Drawing.Point(0, 0);
            this.dataSourcesGrid.Name = "dataSourcesGrid";
            this.dataSourcesGrid.Size = new System.Drawing.Size(242, 285);
            this.dataSourcesGrid.TabIndex = 1;
            this.dataSourcesGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataSourcesGrid_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 24);
            this.panel1.TabIndex = 2;
            // 
            // btnSet
            // 
            this.btnSet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSet.Location = new System.Drawing.Point(167, 0);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 24);
            this.btnSet.TabIndex = 0;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // Source
            // 
            this.Source.DataPropertyName = "Key";
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Visible = false;
            // 
            // MapDatasources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 285);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataSourcesGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MapDatasources";
            this.Text = "Map Data sources";
            this.Load += new System.EventHandler(this.MapDatasources_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSourcesGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataSourcesGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewComboBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}