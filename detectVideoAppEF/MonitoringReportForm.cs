using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using detectVideoApp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace detectVideoAppEF
{
    public partial class MonitoringReportForm : Form
    {
        #region members
        private MonitoringDetailDbService _fileMonitorDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDbService;
        #endregion
        #region constructor
        public MonitoringReportForm()
        {
            InitializeComponent();
            _fileMonitorDbService = new MonitoringDetailDbService();
            _configurationModificationDbService = new ConfigurationModificationDetailDbService();
            FillingComboboxWithObjects();

            //   chooseHistoryComboBox.SelectedIndex = 0;

        }
        #endregion

        private void MonitoringReportBtn_Click(object sender, EventArgs e)
        {

            if (monitoringReportDataGridView.Rows.Count > 0)
            {
                monitoringReportDataGridView.DataSource = null;
                monitoringReportDataGridView.Rows.Clear();

            }
            if (monitoringReportDataGridView.Columns.Contains("openFile"))
            {
                monitoringReportDataGridView.Columns.Remove("openFile");
            }

            monitoringReportDataGridView.ReadOnly = true;
            try
            {
                if (extensionsComboBox.SelectedItem.ToString() == "all")
                {
                    showVideosCheckBox.Visible = true;
                    showPhotosCheckBox.Visible = true;
           

                    if (showVideosCheckBox.Checked && showPhotosCheckBox.Checked)
                    {
                        var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), true, true);

                        var closestMonitoringDetailToInputFromDateTimePicker = _fileMonitorDbService.ReadFromDb_ClosestMonitoringDetail(DateTime.Parse(fromDateTimePicker.Text), true);

                        if (closestMonitoringDetailToInputFromDateTimePicker != null)
                        {



                            bool containsItem = monitoringReportBetweenTwoDatesList.Any(item => item.FileName == closestMonitoringDetailToInputFromDateTimePicker.FileName);
                            if (closestMonitoringDetailToInputFromDateTimePicker != null && !containsItem
                               && DateTimeCalculator.IsBetweenTwoDates(date: (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp, fromDate: DateTime.Parse(fromDateTimePicker.Text), toDate: DateTime.Parse(toDateTimePicker.Text))
                               && DateTime.Parse(fromDateTimePicker.Text) >= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.StartTimestamp && DateTime.Parse(fromDateTimePicker.Text) <= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp)
                            {

                                monitoringReportBetweenTwoDatesList.Add(closestMonitoringDetailToInputFromDateTimePicker);

                            }

                        }

                        monitoringReportDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                    }
                    if (showPhotosCheckBox.Checked && !showVideosCheckBox.Checked)
                    {
                        var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), false, true);

                        monitoringReportDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                    }
                    if (!showPhotosCheckBox.Checked && showVideosCheckBox.Checked)
                    {
                        var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), true, false);

                        var closestMonitoringDetailToInputFromDateTimePicker = _fileMonitorDbService.ReadFromDb_ClosestMonitoringDetail(DateTime.Parse(fromDateTimePicker.Text), true);

                        if (closestMonitoringDetailToInputFromDateTimePicker != null)
                        {



                            bool containsItem = monitoringReportBetweenTwoDatesList.Any(item => item.FileName == closestMonitoringDetailToInputFromDateTimePicker.FileName);
                            if (closestMonitoringDetailToInputFromDateTimePicker != null && !containsItem
                               && DateTimeCalculator.IsBetweenTwoDates(date: (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp, fromDate: DateTime.Parse(fromDateTimePicker.Text), toDate: DateTime.Parse(toDateTimePicker.Text))
                               && DateTime.Parse(fromDateTimePicker.Text) >= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.StartTimestamp && DateTime.Parse(fromDateTimePicker.Text) <= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp)
                            {

                                monitoringReportBetweenTwoDatesList.Add(closestMonitoringDetailToInputFromDateTimePicker);

                            }

                        }
                        monitoringReportDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                    }

                }
                else
                {
                    showVideosCheckBox.Visible = false;
                    showPhotosCheckBox.Visible = false;
                    if (Enum.TryParse((extensionsComboBox.SelectedItem.ToString()), out VideoExtensionsEnum extension))
                    {
                        var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), videoExtension: extension.ToString());

                        var closestMonitoringDetailToInputFromDateTimePicker = _fileMonitorDbService.ReadFromDb_ClosestMonitoringDetail(DateTime.Parse(fromDateTimePicker.Text), true, extension.ToString());

                        if (closestMonitoringDetailToInputFromDateTimePicker != null)
                        {



                            bool containsItem = monitoringReportBetweenTwoDatesList.Any(item => item.FileName == closestMonitoringDetailToInputFromDateTimePicker.FileName);
                            if (closestMonitoringDetailToInputFromDateTimePicker != null && !containsItem
                               && DateTimeCalculator.IsBetweenTwoDates(date: (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp, fromDate: DateTime.Parse(fromDateTimePicker.Text), toDate: DateTime.Parse(toDateTimePicker.Text))
                               && DateTime.Parse(fromDateTimePicker.Text) >= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.StartTimestamp && DateTime.Parse(fromDateTimePicker.Text) <= (DateTime)closestMonitoringDetailToInputFromDateTimePicker.EndTimestamp)
                            {

                                monitoringReportBetweenTwoDatesList.Add(closestMonitoringDetailToInputFromDateTimePicker);

                            }

                        }
                        monitoringReportDataGridView.DataSource = monitoringReportBetweenTwoDatesList;

                    }
                    if (Enum.TryParse((extensionsComboBox.SelectedItem.ToString()), out PhotoExtensionsEnum photoExtension))
                    {
                        var monitoringReportBetweenTwoDatesList = _fileMonitorDbService.ReadFromDb_MonitoringDetails_BetweenDates(DateTime.Parse(fromDateTimePicker.Text), DateTime.Parse(toDateTimePicker.Text), false, true);

                        monitoringReportDataGridView.DataSource = monitoringReportBetweenTwoDatesList;
                    }
                }



                //Add the column to the DataGridView
                if (!monitoringReportDataGridView.Columns.Contains("openFile"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "media_files";
                    btn.Name = "openFile";
                    btn.Text = "open";
                    btn.UseColumnTextForButtonValue = true;
                    monitoringReportDataGridView.Columns.Add(btn);
                }
                monitoringReportDataGridView.Columns[0].Width = 130;
                monitoringReportDataGridView.Columns[1].Width = 80;
                monitoringReportDataGridView.Columns[2].Width = 400;
                monitoringReportDataGridView.Columns[3].Width = 120;
                monitoringReportDataGridView.Columns[4].Width = 120;
                monitoringReportDataGridView.Columns[5].Width = 120;
                monitoringReportDataGridView.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                monitoringReportDataGridView.Columns[5].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }
        public void FillingComboboxWithObjects()
        {
            extensionsComboBox.Items.Clear();

            var videoExtensionsObjects = _fileMonitorDbService.ReadDb_VideoExtensions();
            var photoExtensionsObject = _fileMonitorDbService.ReadDb_PhotoExtensions();
            extensionsComboBox.Items.Add("all");
            videoExtensionsObjects.ForEach(c => extensionsComboBox.Items.Add(c.ToString()));
            photoExtensionsObject.ForEach(c => extensionsComboBox.Items.Add(c.ToString()));

            extensionsComboBox.DisplayMember = "CameraName";





        }

        private void ExtensionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (monitoringReportDataGridView.Rows.Count > 0)
            {
                monitoringReportDataGridView.DataSource = null;
                monitoringReportDataGridView.Rows.Clear();
            }
            if (monitoringReportDataGridView.Columns.Contains("openFile"))
            {
                monitoringReportDataGridView.Columns.Remove("openFile");
            }
            if (extensionsComboBox.SelectedIndex == 0)
            {
                mediaFilesgroupBox.Visible = true;
                showVideosCheckBox.Visible = true;
                showPhotosCheckBox.Visible = true;
                showVideosCheckBox.Checked = true;
                showPhotosCheckBox.Checked = true;
            }
            if (extensionsComboBox.SelectedIndex > 0)
            {
                showVideosCheckBox.Visible = false;
                showPhotosCheckBox.Visible = false;
                mediaFilesgroupBox.Visible = false;

            }
        }

        private void MonitoringReportDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {

                try
                {
                    //getting a specific file path from the table
                    var filePath = this.monitoringReportDataGridView[2, e.RowIndex].Value.ToString();

                    if (Enum.TryParse((FileService.GetFileExtension(filePath).Substring(1)), out PhotoExtensionsEnum PhotoExten))
                    {
                        Process.Start(filePath);
                    }
                    else
                    {
                        Process test = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();


                        var existStartDateTime = _fileMonitorDbService.ReadDb_Timestamps_ForFile(filePath).startTimestamp;
                        var existeEndTime = _fileMonitorDbService.ReadDb_Timestamps_ForFile(filePath).endTimestamp;
                        startInfo.FileName = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

                        string start = "0";
                        string stop = "0";

                        if (DateTimeCalculator.IsBetweenTwoDates(DateTime.Parse(fromDateTimePicker.Text), existStartDateTime, existeEndTime) || DateTimeCalculator.IsBetweenTwoDates(DateTime.Parse(toDateTimePicker.Text), existStartDateTime, existeEndTime))
                        {
                            var substrResultOFStartTime = DateTimeCalculator.SubstactTwoDates(existStartDateTime, DateTime.Parse(fromDateTimePicker.Text));
                            var substrResultOfEndTime = DateTimeCalculator.SubstactTwoDates(existStartDateTime, DateTime.Parse(toDateTimePicker.Text));
                            var videoDuration = FileService.VideoTotalDuration(existStartDateTime, existeEndTime);
                            if (substrResultOFStartTime > 0 && substrResultOFStartTime < videoDuration && DateTimeCalculator.isEqual(DateTime.Parse(fromDateTimePicker.Text).Date, existStartDateTime.Date))
                            {
                                start = substrResultOFStartTime.ToString();

                            }
                            if (substrResultOfEndTime > 0 && substrResultOfEndTime < videoDuration && DateTimeCalculator.isEqual(DateTime.Parse(toDateTimePicker.Text).Date, existeEndTime.Date))
                            {
                                stop = substrResultOfEndTime.ToString();
                            }
                        }


                        startInfo.Arguments = $"\"" + filePath + "\"" + " --start-time" + " " + start + " --stop-time " + stop;


                        Process.Start(startInfo);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

            }
        }

        private void MonitoringReportForm_Load(object sender, EventArgs e)
        {


            if (extensionsComboBox.Items.Count > 0)
            {
                showVideosCheckBox.Visible = true;
                showPhotosCheckBox.Visible = true;
                showVideosCheckBox.Checked = true;
                showPhotosCheckBox.Checked = true;
                extensionsComboBox.SelectedIndex = 0;
            }
        }
    }
}
