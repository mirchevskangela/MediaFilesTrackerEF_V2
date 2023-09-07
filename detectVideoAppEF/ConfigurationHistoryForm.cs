using DbServicesEFCore.DbServices;
using System;
using System.Windows.Forms;

namespace detectVideoAppEF
{
    public partial class ConfigurationHistoryForm : Form
    {
        #region members

        private ConfigurationModificationDetailDbService _configurationModificationDbService;
        #endregion
        #region constructor
        public ConfigurationHistoryForm()
        {
            InitializeComponent();
            _configurationModificationDbService = new ConfigurationModificationDetailDbService();


        }
        #endregion


        private void ConfigurationHistoryForm_Load(object sender, EventArgs e)
        {
            var modifiedConfigurationsList = _configurationModificationDbService.ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text));


            configurationsHistoryDataGridView.DataSource = modifiedConfigurationsList;

            configurationsHistoryDataGridView.Columns[0].Width = 100;
            configurationsHistoryDataGridView.Columns[1].Width = 100;
            configurationsHistoryDataGridView.Columns[2].Width = 100;
            configurationsHistoryDataGridView.Columns[3].Width = 490;
            configurationsHistoryDataGridView.Columns[4].Width = 100;
            configurationsHistoryDataGridView.Columns[5].Width = 100;


        }

        private void GetConfigurationsHistoryBtn_Click(object sender, EventArgs e)
        {
            if (searchCameraConfigurationTxtBox.Text == "")
            {
                var modifiedConfigurationsList = _configurationModificationDbService.ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text));


                configurationsHistoryDataGridView.DataSource = modifiedConfigurationsList;

                configurationsHistoryDataGridView.Columns[0].Width = 100;
                configurationsHistoryDataGridView.Columns[1].Width = 100;
                configurationsHistoryDataGridView.Columns[2].Width = 100;
                configurationsHistoryDataGridView.Columns[3].Width = 490;
                configurationsHistoryDataGridView.Columns[4].Width = 100;
                configurationsHistoryDataGridView.Columns[5].Width = 100;
            }
            if (searchCameraConfigurationTxtBox.Text != "")
            {
                var modifiedConfigurationsList = _configurationModificationDbService.ReadDb_Configuration_ModificationDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), searchCameraConfigurationTxtBox.Text);


                configurationsHistoryDataGridView.DataSource = modifiedConfigurationsList;

                configurationsHistoryDataGridView.Columns[0].Width = 100;
                configurationsHistoryDataGridView.Columns[1].Width = 100;
                configurationsHistoryDataGridView.Columns[2].Width = 100;
                configurationsHistoryDataGridView.Columns[3].Width = 490;
                configurationsHistoryDataGridView.Columns[4].Width = 100;
                configurationsHistoryDataGridView.Columns[5].Width = 100;
            }
        }
    }
}
