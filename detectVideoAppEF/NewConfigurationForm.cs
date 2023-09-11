using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.DbServices;
using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace detectVideoApp
{
    public partial class NewConfigurationForm : Form
    {
        #region Members
        public event EventHandler<ConfigurationsUpdateEventArgs> NewConfigurationCreatedNotify;
        private CameraConfigurationDbService _cameraConfigurationDbService;
        private ConfigurationModificationDetailDbService _configurationModificationDetailDbService;
        private ClassLibrary.ModelClass.CameraConfiguration _cameraConfiguration = new ClassLibrary.ModelClass.CameraConfiguration();
        private ConfigurationModificationDetail _modifiedConfiguration = new ConfigurationModificationDetail();



        #endregion

        #region Cosntructors
        public NewConfigurationForm(CameraConfigurationDbService cameraConfigurationDbService)
        {
            InitializeComponent();
            _cameraConfigurationDbService = cameraConfigurationDbService;
            _configurationModificationDetailDbService = new ConfigurationModificationDetailDbService();
            _cameraConfiguration.PhotoExtensions = new List<PhotoExtension_CameraConfiguration>() { };
            _modifiedConfiguration.PhotoExtensions = new List<PhotoExtension_ConfigurationModificationDetail>() { };
            _cameraConfiguration.VideoExtensions = new List<VideoExtension_CameraConfiguration>() { };
            _modifiedConfiguration.VideoExtensions = new List<VideoExtension_ConfigurationModificationDetail> { };
            _cameraConfiguration.Folders = new List<DbServiceEFCoreV4.Folder_CameraConfiguration>() { };
            _modifiedConfiguration.Folders = new List<Folder_ConfigurationModificationDetail>() { };

        }
        #endregion

        #region Events

        // browse folder button
        private void BrowseFolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPathTxtBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /// <summary>
        /// Adds new configuration to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveConfiguration_Click(object sender, EventArgs e)
        {


            if (cameraNameTxtBox.Text == "")
            {
                MessageBox.Show("insert camera");
            }
            else if (_cameraConfiguration.Folders.Count == 0)
            {
                MessageBox.Show("Must contain at least one folder!");
            }
            else if (_cameraConfigurationDbService.ReadFromDb_Configuration_InDetail(cameraNameTxtBox.Text.ToString()).name.ToLower() == cameraNameTxtBox.Text.ToString().ToLower())
            {
                MessageBox.Show(cameraNameTxtBox.Text + " is alredy entered, please insert another camera name");

            }

            else
            {
                try
                {
                    if (_cameraConfiguration.VideoExtensions.Count > 0 || _cameraConfiguration.PhotoExtensions.Count > 0)
                    {
                        _cameraConfiguration.CameraName = cameraNameTxtBox.Text;
                        _cameraConfiguration.Timestamp = DateTime.Now;
                        _modifiedConfiguration.CameraName = cameraNameTxtBox.Text;
                        _modifiedConfiguration.Item = "New Configuration";
                        _cameraConfigurationDbService.WriteDb_AddCameraConfiguration(_cameraConfiguration);



                        _configurationModificationDetailDbService.WriteDb_Configuration_Modification(_modifiedConfiguration, true, false, false, false);
                        OnNewConfigurationCreated(new ConfigurationsUpdateEventArgs(true));


                        photoExtListView.Items.Clear();
                        videoExtListView.Items.Clear();
                        pathListView.Items.Clear();
                        cameraNameTxtBox.Text = "";
                        NewConfigurationForm_Load(sender, e);
                        MessageBox.Show("New Configuration Added");

                    }
                    else
                    {
                        MessageBox.Show("must contain at least one exstension");

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //call event

            }
        }
        /// <summary>
        /// Adds a new extension to the configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVideoExtenBtn_Click(object sender, EventArgs e)
        {
            AddVideoExtension();
        }
        /// <summary>
        ///  Adds a new photo extension to the configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPhotoExtenBtn_Click(object sender, EventArgs e)
        {
            AddPhotoExtension();
        }
        /// <summary>
        ///  Adds a new folder path to the configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFolderPathBtn_Click(object sender, EventArgs e)
        {
            AddFolderPath();
        }
        #endregion
        protected virtual void OnNewConfigurationCreated(ConfigurationsUpdateEventArgs e)
        {
            NewConfigurationCreatedNotify?.Invoke(this, e);

        }
        private void NewConfigurationForm_Load(object sender, EventArgs e)
        {
            cameraNameWarningLabel.Visible = false;

        }
        private void CameraNameTxtBox_TextChanged(object sender, EventArgs e)
        {

            if (cameraNameTxtBox.Text.ToString() != "" && _cameraConfigurationDbService.ReadFromDb_Configuration_InDetail(cameraNameTxtBox.Text.ToString()).name.ToLower() == cameraNameTxtBox.Text.ToString().ToLower())
            {
                cameraNameWarningLabel.Visible = true;

            }
            else if (cameraNameTxtBox.Text.ToString() == " ")
            {
                cameraNameWarningLabel.Visible = false;

            }
            else
            {
                cameraNameWarningLabel.Visible = false;

            }
        }

        /// <summary>
        /// Adds the folder path value provided by user to the list only if the path is valid and doesn't already exist in the list.
        /// </summary>
        public void AddFolderPath()
        {
            if (Directory.Exists(folderPathTxtBox.Text.ToLower()))
            {
                bool exists = false;
                Folder folder = new Folder();
                var FolderExistInDb = _cameraConfigurationDbService.ReadDb_CheckIfFolderObjectExistInDb(folderPathTxtBox.Text);
                if (FolderExistInDb)
                {
                    folder = _cameraConfigurationDbService.ReadDb_FolderObject(folderPathTxtBox.Text);
                    if (_cameraConfiguration.Folders != null && _cameraConfiguration.Folders?.Count > 0)
                    {
                        exists = _cameraConfiguration.Folders.Any(f =>
                                 f.Folder?.FolderPath == folder.FolderPath);
                    }
                    if (!exists)
                    {
                        ListViewItem lvi = new ListViewItem(folderPathTxtBox.Text);
                        _cameraConfiguration.Folders.Add(new DbServiceEFCoreV4.Folder_CameraConfiguration { FolderId = folder.Id });

                        _modifiedConfiguration.Folders.Add(new Folder_ConfigurationModificationDetail { FolderId = folder.Id });
                        pathListView.Items.Add(lvi);
                        folderPathTxtBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(folderPathTxtBox.Text + " was alredy entered");
                        folderPathTxtBox.Text = "";
                    }
                }
                else
                {
                    folder.FolderPath = folderPathTxtBox.Text;
                    ListViewItem lvi = new ListViewItem(folderPathTxtBox.Text);
                    _cameraConfiguration.Folders.Add(new DbServiceEFCoreV4.Folder_CameraConfiguration { Folder = folder });
                    _modifiedConfiguration.Folders.Add(new Folder_ConfigurationModificationDetail { FolderId = folder.Id });
                    pathListView.Items.Add(lvi);
                    folderPathTxtBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show(folderPathTxtBox.Text + " doesn't exist");

            }

        }
        /// <summary>
        ///  Adds the video extension provided by the user to a list only if the extension is valid and doesn't already exist in the list
        /// </summary>
        public void AddVideoExtension()
        {
            if (addVideoExteTxtBox.Text != "")
            {

                if (Enum.TryParse((addVideoExteTxtBox.Text.ToLower()), out VideoExtensionsEnum extension))
                {
                    bool exists = false;
                    if (_cameraConfiguration.VideoExtensions != null && _cameraConfiguration.PhotoExtensions.Count > 0)
                    {
                        exists = _cameraConfiguration.VideoExtensions.Any(ve =>
                             ve.VideoExtensionId == (int)extension);
                    }

                    if (!exists)
                    {
                        _cameraConfiguration.VideoExtensions.Add(new VideoExtension_CameraConfiguration { VideoExtensionId = (int)extension });
                        _modifiedConfiguration.VideoExtensions.Add(new VideoExtension_ConfigurationModificationDetail { VideoExtensionId = (int)extension });
                        ListViewItem lvi = new ListViewItem(extension.ToString());
                        videoExtListView.Items.Add(lvi);
                        addVideoExteTxtBox.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("insert valid video extension");
                }
            }
        }
        /// <summary>
        ///  Adds the photo extension provided by the user to a list only if the extension is valid and doesn't already exist in the list
        /// </summary>
        public void AddPhotoExtension()
        {

            if (addPhotoExteTxtBox.Text != "")
            {
                if (Enum.TryParse((addPhotoExteTxtBox.Text.ToLower()), out PhotoExtensionsEnum extension))

                {
                    bool exists = false;
                    if (_cameraConfiguration.PhotoExtensions != null && _cameraConfiguration.PhotoExtensions.Count > 0)
                    {
                        exists = _cameraConfiguration.PhotoExtensions.Any(ve =>
                         ve.PhotoExtensionId == (int)extension);
                    }
                    if (!exists)
                    {

                        _cameraConfiguration.PhotoExtensions.Add(new PhotoExtension_CameraConfiguration { PhotoExtensionId = (int)extension });
                        _modifiedConfiguration.PhotoExtensions.Add(new PhotoExtension_ConfigurationModificationDetail { PhotoExtensionId = (int)extension });

                        ListViewItem lvi = new ListViewItem(extension.ToString());
                        photoExtListView.Items.Add(lvi);
                        addPhotoExteTxtBox.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("insert valid photo extension");
                }
            }
        }
    }
}


