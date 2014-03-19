using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ReportSync.Properties;

namespace ReportSync
{
    public partial class MapDatasources : Form
    {
        public Dictionary<string, string> SourceDs;
        public Dictionary<string, string> DestDs;

        public MapDatasources()
        {
            InitializeComponent();
        }

        private void MapDatasources_Load(object sender, EventArgs e)
        {
            if (SourceDs == null || DestDs == null)
            {
                MessageBox.Show(Resources.MSGBOX_LoadSouceAndDest, Resources.DatasourceNotLoaded, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                dataSourcesGrid.DataSource = new BindingSource(SourceDs, "");
                var dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"];
                if (dataGridViewComboBoxColumn != null)
                    dataGridViewComboBoxColumn.DataSource = new BindingSource(DestDs, "");

                var gridViewComboBoxColumn = (DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"];
                if (gridViewComboBoxColumn != null)
                    gridViewComboBoxColumn.DisplayMember = "Value";

                var viewComboBoxColumn = (DataGridViewComboBoxColumn)dataSourcesGrid.Columns["Destination"];
                if (viewComboBoxColumn != null)
                    viewComboBoxColumn.ValueMember = "Value";

                dataSourcesGrid.DataError += dataSourcesGrid_DataError;
            }
        }

        static void dataSourcesGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ToString(), Resources.Error_on_datasource, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            var i=0;
            foreach (var entry in SourceDs)
            {
                if (dataSourcesGrid["Destination", i].Value != null)
                {
                    var destPath = dataSourcesGrid["Destination", i].Value.ToString();


                    if (DestDs.ContainsKey(entry.Key))
                        DestDs[entry.Key] = destPath;
                    else
                        DestDs.Add(entry.Key, destPath);
                }
                i++;
            }
            DialogResult = DialogResult.OK;
        }

        private void dataSourcesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var i = 0;
            foreach (var entry in SourceDs)
            {
                if (DestDs.ContainsKey(entry.Key))
                {
                    dataSourcesGrid["Destination", i].Value = DestDs[entry.Key];
                }
                i++;
            }
        }
    }
}
