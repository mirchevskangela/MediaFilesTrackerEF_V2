using DbServiceEFCoreV4.ModelClass;
using DbServicesEFCore.DbServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace detectVideoApp
{
    public class FileMonitoringService
    {
        #region Members
        private List<FileSystemWatcher> _fileSystemWatchers = new List<FileSystemWatcher>();
        public event EventHandler<MonitoringDetailsEventArgs> MonitoringDetailNotify;
        private MonitoringDetailDbService _monitoringDetailDbService;
        private ClassLibrary.ModelClass.CameraConfiguration _cameraConfiguration;
        #endregion

        #region Constructors

        public FileMonitoringService(ClassLibrary.ModelClass.CameraConfiguration cameraConfiguration)
        {
            _monitoringDetailDbService = new MonitoringDetailDbService();
            _cameraConfiguration = cameraConfiguration;

            var folders = _cameraConfiguration.Folders;
            foreach (var FolderPath in folders)
            {
                FileSystemWatcher folderWatcher = new FileSystemWatcher();
                folderWatcher.Path = FolderPath.Folder.ToString();
                folderWatcher.IncludeSubdirectories = true;
                folderWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.CreationTime;
                folderWatcher.Created += new FileSystemEventHandler(FileCreate);
                folderWatcher.Changed += new FileSystemEventHandler(FileChange);
                folderWatcher.Filter = "";
                folderWatcher.EnableRaisingEvents = true;

                _fileSystemWatchers.Add(folderWatcher);
            }

        }

        #endregion
        #region Events
        private void FileCreate(object sender, FileSystemEventArgs e)
        {
            string strFileExt = FileService.GetFileExtension(e.Name);


            {
                if (Enum.TryParse((strFileExt.Substring(1)), out VideoExtensionsEnum videoExten))
                {
                    bool exists = _cameraConfiguration.VideoExtensions.Any(ve => ve.VideoExtensionId == (int)videoExten);
                    if (exists)
                    {
                        _monitoringDetailDbService.WriteInDb_NewMonitoringDetail(_cameraConfiguration, e.FullPath.ToString(), e.Name.ToString(), strFileExt, true);
                        OnCreatedOrChangedFile(new MonitoringDetailsEventArgs(ActionsEnum.Created.ToString(), _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                    }
                }
                if (Enum.TryParse((strFileExt.Substring(1)), out PhotoExtensionsEnum PhotoExten))
                {
                    bool exists = _cameraConfiguration.PhotoExtensions.Any(ve => ve.PhotoExtensionId == (int)PhotoExten);
                    if (exists)
                    {
                        _monitoringDetailDbService.WriteInDb_NewMonitoringDetail(_cameraConfiguration, e.FullPath.ToString(), e.Name.ToString(), strFileExt, false);
                        OnCreatedOrChangedFile(new MonitoringDetailsEventArgs(ActionsEnum.Created.ToString(), _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                    }
                }
            }


        }
        /// <summary>
        /// Calls the event handler method registered with the MonitoringDetails event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCreatedOrChangedFile(MonitoringDetailsEventArgs e)
        {
            MonitoringDetailNotify?.Invoke(this, e);

        }
        private void FileChange(object sender, FileSystemEventArgs e)
        {
            if (Enum.TryParse((FileService.GetFileExtension(e.Name.ToString()).Substring(1)), out PhotoExtensionsEnum photoExten))
            {
                bool exists = _cameraConfiguration.PhotoExtensions.Any(ve => ve.PhotoExtensionId == (int)photoExten);
                if (exists)
                {
                    _monitoringDetailDbService.UpdateDb_MonitoringDetail(e.Name.ToString());
                    OnCreatedOrChangedFile(new MonitoringDetailsEventArgs("File changed ", _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                }
            }
       
            if (Enum.TryParse((e.Name.ToString()), out VideoExtensionsEnum extension))
            {
                bool exists = _cameraConfiguration.VideoExtensions.Any(ve => ve.VideoExtensionId == (int)extension);
                if (exists)
                {
                    _monitoringDetailDbService.UpdateDb_MonitoringDetail(e.Name.ToString());
                    OnCreatedOrChangedFile(new MonitoringDetailsEventArgs("File changed ", _cameraConfiguration.CameraName, e.FullPath.ToString(), e.Name.ToString(), DateTime.Now));
                }
            }
        }
        #endregion
        /// <summary>
        /// Stops monitoring process
        /// </summary>
        public void StopMonitoring()
        {
            foreach (var fileSystemWatcher in _fileSystemWatchers)
            {
                fileSystemWatcher.EnableRaisingEvents = false;
                fileSystemWatcher.Dispose();
            }
        }
    }
}
