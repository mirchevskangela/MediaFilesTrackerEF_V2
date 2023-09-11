using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class ModifyConfigurationForm : Form
    {

        #region Cosntructors
        public ModifyConfigurationForm(CameraConfigurationDbService cameraConfigurationDbService)
        {
            InitializeComponent();
            _cameraConfigurationDbService = cameraConfigurationDbService;
            _configurationModificationDetailDbService = new ConfigurationModificationDetailDbService();
        }
        #endregion

        #region Members
        public event EventHandler<ConfigurationsUpdateEventArgs> ConfigurationModifiedNotify;
        NewConfigurationForm _newConfigurationForm;
        private CameraConfigurationDbService _cameraConfigurationDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDetailDbService;
        #endregion
        #region Events
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            _newConfigurationForm = new NewConfigurationForm(_cameraConfigurationDbService);
            _newConfigurationForm.NewConfigurationCreatedNotify += UpdateCombobox;
            FillComboboxWtihCameraConfigurations();
            if (displayExistingCamerasComboBox.Items.Count > 0)
            {
                displayExistingCamerasComboBox.SelectedIndex = 0;
            }
        }
        private void DeleteConfigurationBtn_Click(object sender, EventArgs e)
        {
            var selectedConfigurationObject = (ClassLibrary.ModelClass.CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
            if (_cameraConfigurationDbService.UpdateDb_DeleteConfiguration(selectedConfigurationObject))
            {
                MessageBox.Show("Configuration Deleted");
                FillComboboxWtihCameraConfigurations();
                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));
                ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(selectedConfigurationObject, "configuration");
                _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, true, false, false);

            }

        }
        /// <summary>
        /// Updates the combobox with the added configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCombobox(object sender, ConfigurationsUpdateEventArgs e)
        {
            if (e.IsCreated)
            {
                FillComboboxWtihCameraConfigurations();

            }
        }
        private void FolderPathsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {

                    if (this.folderPathsDataGridView[0, e.RowIndex].Value != null && this.folderPathsDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        var insertedValue = this.folderPathsDataGridView[0, e.RowIndex].Value.ToString();
                        var buttonCell = (DataGridViewButtonCell)folderPathsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var cameraConfigurationObject = (ClassLibrary.ModelClass.CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                        if (buttonCell.Value.ToString() == "Delete")
                        {
                            var isFolderPathDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(cameraConfigurationObject, folderPath: insertedValue);
                            if (isFolderPathDeleted)
                            {
                                ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(cameraConfigurationObject, insertedValue);
                                _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, true, false, false);
                                MessageBox.Show(insertedValue + " deleted successfully");
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));


                            }
                            else
                            {
                                MessageBox.Show("Must contain at least one folder");

                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {

                            if (System.IO.Directory.Exists(insertedValue))
                            {
                                if (_cameraConfigurationDbService.UpdateDb_AddConfigurationDetail(cameraConfigurationObject, insertedFolderPath: insertedValue))
                                {
                                    ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(cameraConfigurationObject, insertedValue);

                                    _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, false, true, false);
                                    MessageBox.Show(insertedValue + " added successfully");
                                    OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));
                                    DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    MessageBox.Show(insertedValue + " is alredy entered");
                                }

                            }
                            else
                            {
                                MessageBox.Show("insert a valid path");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PhotoExtensDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    if (this.photoExtensDataGridView[0, e.RowIndex].Value != null && this.photoExtensDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        var selectedConfigurationObject = (ClassLibrary.ModelClass.CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                        var buttonCell = (DataGridViewButtonCell)photoExtensDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var insertedData = this.photoExtensDataGridView[0, e.RowIndex].Value.ToString();


                        if (buttonCell.Value.ToString() == "Delete")
                        {

                            var isPhotoDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(configurationObject: selectedConfigurationObject, photoExtension: insertedData);
                            if (isPhotoDeleted)
                            {
                                ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(selectedConfigurationObject, insertedData);
                                _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, true, false, false);
                                MessageBox.Show(insertedData + " deleted successfully");
                                this.photoExtensDataGridView[0, e.RowIndex].Value = null;
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));



                            }
                            else
                            {
                                MessageBox.Show("Must contain at least one extension");

                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {

                            if (Enum.TryParse((insertedData), out PhotoExtensionsEnum extension))
                            {
                                bool exists = false;
                                if (selectedConfigurationObject.PhotoExtensions.Count > 0)
                                {
                                    exists = selectedConfigurationObject.PhotoExtensions.Any(ve => ve.PhotoExtensionId == (int)extension);

                                }
                                if (exists)
                                {
                                    MessageBox.Show(insertedData + " is alredy entered");
                                }
                                else
                                {
                                    if (_cameraConfigurationDbService.UpdateDb_AddConfigurationDetail(selectedConfigurationObject, photoExtension: extension.ToString()))
                                    {
                                        ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(selectedConfigurationObject, insertedData);

                                        _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, false, true, false);
                                        MessageBox.Show(insertedData + " added successfully");
                                        OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));

                                        DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                    }
                                    else
                                    {
                                        MessageBox.Show(insertedData + " something went wrong");

                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("insert a valid extension");

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void VideoExtensDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {

                    if (this.videoExtensDataGridView[0, e.RowIndex].Value != null && this.videoExtensDataGridView[0, e.RowIndex].Value.ToString() != "")
                    {
                        var insertedData = this.videoExtensDataGridView[0, e.RowIndex].Value.ToString();
                        var buttonCell = (DataGridViewButtonCell)videoExtensDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        var selectedConfigurationObject = (ClassLibrary.ModelClass.CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;

                        if (buttonCell.Value.ToString() == "Delete")
                        {
                            var isVideoExtensionDeleted = _cameraConfigurationDbService.UpdateDb_DeleteConfigurationDetail(selectedConfigurationObject, videoExtension: insertedData);
                            if (isVideoExtensionDeleted)
                            {

                                MessageBox.Show(insertedData + " deleted successfully");

                                this.videoExtensDataGridView[0, e.RowIndex].Value = null;
                                DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);
                                OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));
                                ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(selectedConfigurationObject, insertedData);

                                _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, true, false, false);
                            }
                            else
                            {
                                MessageBox.Show("Must contain at least one extension");

                            }
                        }
                        else if (buttonCell.Value.ToString() == "Add")
                        {


                            if (Enum.TryParse((insertedData), out VideoExtensionsEnum extension))
                            {
                                bool exists = selectedConfigurationObject.VideoExtensions.Any(ve => ve.VideoExtensionId == (int)extension);

                                if (exists)
                                {
                                    MessageBox.Show(insertedData + " is alredy entered");
                                }
                                else
                                {
                                    if (_cameraConfigurationDbService.UpdateDb_AddConfigurationDetail(selectedConfigurationObject, videoExtension: extension.ToString()))
                                    {
                                        ConfigurationModificationDetail configurationModificationDetail = ConfigurationModificationDetail(selectedConfigurationObject, insertedData);

                                        _configurationModificationDetailDbService.WriteDb_Configuration_Modification(configurationModificationDetail, false, false, true, false);
                                        MessageBox.Show(insertedData + " added successfully");
                                        OnConfigurationDeleted(new ConfigurationsUpdateEventArgs(true));
                                        DisplayExistingCamerasComboBox_SelectedIndexChanged(sender, e);

                                    }
                                    else
                                    {
                                        MessageBox.Show(insertedData + " something went wrong");

                                    }




                                }
                            }
                            else
                            {
                                MessageBox.Show("insert a valid extension");
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void DisplayExistingCamerasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(displayExistingCamerasComboBox.GetItemText(displayExistingCamerasComboBox.SelectedItem)))
            {
                var selectedConfigurationObject = (ClassLibrary.ModelClass.CameraConfiguration)displayExistingCamerasComboBox.SelectedItem;
                if (selectedConfigurationObject != null)
                {

                    FillDataGridView(selectedConfigurationObject.VideoExtensions, videoExtensDataGridView, "Video Extensions", 100);
                    FillDataGridView(selectedConfigurationObject.Folders, folderPathsDataGridView, "Folder Paths", 354);
                    FillDataGridView(selectedConfigurationObject.PhotoExtensions, photoExtensDataGridView, "Photo Extensions", 100);
                }
            }
        }
        protected virtual void OnConfigurationDeleted(ConfigurationsUpdateEventArgs e)
        {
            ConfigurationModifiedNotify?.Invoke(this, e);

        }
        #endregion
        /// <summary>
        /// fills combobox with configuration objects from database
        /// </summary>
        public void FillComboboxWtihCameraConfigurations()
        {
            displayExistingCamerasComboBox.Items.Clear();
            var configurationObjects = _cameraConfigurationDbService.ReadDb_AllCameraConfigurations();
            configurationObjects.ForEach(c => displayExistingCamerasComboBox.Items.Add(c));
            displayExistingCamerasComboBox.DisplayMember = "CameraName";
            if (displayExistingCamerasComboBox.Items.Count > 0)
            {
                displayExistingCamerasComboBox.SelectedIndex = 0;
            }
            else
            {
                folderPathsDataGridView.Rows.Clear();
                photoExtensDataGridView.Rows.Clear();
                videoExtensDataGridView.Rows.Clear();
            }


        }
        public void FillDataGridView<T>(List<T> list, DataGridView dataGridViewName, string columnName, int columnWidth)
        {
            if (dataGridViewName.Rows.Count > 0)
            {
                dataGridViewName.Rows.Clear();

            }
            dataGridViewName.ReadOnly = false;
            dataGridViewName.AllowUserToAddRows = true;
            dataGridViewName.ColumnCount = 2;
            dataGridViewName.Columns[0].Name = columnName;
            dataGridViewName.Columns[0].Width = columnWidth;
            dataGridViewName.RowCount = list.Count + 1;

            if (list.Count > 0 && list != null)
            {


                for (int i = 0; i < list.Count; i++)
                {

                    dataGridViewName.Rows[i].Cells[columnName].Value = list.ElementAt(i).ToString();

                }
            }

            foreach (DataGridViewRow row in dataGridViewName.Rows)
            {
                DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell();
                deleteButtonCell.Value = "Delete";
                row.Cells[1] = deleteButtonCell;
            }

            // Add a button to the second column of the last row
            DataGridViewButtonCell addButtonCell = new DataGridViewButtonCell();
            addButtonCell.Value = "Add";
            dataGridViewName.Rows[dataGridViewName.Rows.Count - 1].Cells[1] = addButtonCell;



        }
        /// <summary>
        /// creates a configuration modification detail object with data from selected configuration
        /// </summary>
        /// <param name="cameraConfigurationObject"></param>
        /// <param name="insertedValue"></param>
        /// <returns></returns>
        public ConfigurationModificationDetail ConfigurationModificationDetail(CameraConfiguration cameraConfigurationObject, string insertedValue)
        {
            ConfigurationModificationDetail configurationModificationDetail = new ConfigurationModificationDetail();
            configurationModificationDetail.CameraName = cameraConfigurationObject.CameraName;
            configurationModificationDetail.Item = insertedValue;
            configurationModificationDetail.VideoExtensions = new List<VideoExtension_ConfigurationModificationDetail>() { };
            configurationModificationDetail.PhotoExtensions = new List<DbServiceEFCoreV4.DbServices.PhotoExtension_ConfigurationModificationDetail>() { };
            configurationModificationDetail.Folders = new List<Folder_ConfigurationModificationDetail> { };

            foreach (var folderCameraConfig in cameraConfigurationObject.Folders)
            {
                int folderId = folderCameraConfig.FolderId;
                configurationModificationDetail.Folders.Add(new Folder_ConfigurationModificationDetail { FolderId = folderId });
            }
            foreach (var folderCameraConfig in cameraConfigurationObject.VideoExtensions)
            {
                int videoExtensionId = folderCameraConfig.VideoExtensionId;
                configurationModificationDetail.VideoExtensions.Add(new VideoExtension_ConfigurationModificationDetail { VideoExtensionId = videoExtensionId });
            }
            foreach (var folderCameraConfig in cameraConfigurationObject.PhotoExtensions)
            {
                int photoExtensionId = folderCameraConfig.PhotoExtensionId;
                configurationModificationDetail.PhotoExtensions.Add(new DbServiceEFCoreV4.DbServices.PhotoExtension_ConfigurationModificationDetail { PhotoExtensionId = photoExtensionId });
            }
            return configurationModificationDetail;
        }
    }
}
