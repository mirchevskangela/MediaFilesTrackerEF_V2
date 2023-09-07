using DbServiceEFCoreV4;
using DbServiceEFCoreV4.ModelClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.ModelClass
{
    public class CameraConfiguration
    {
        #region Fields
        [Key]
        public int Id { get; set; }
        public string CameraName { get; set; }
      //  public string FolderPath { get; set; }
        public List<Folder_CameraConfiguration> Folders { get; set; }
        public List<VideoExtension_CameraConfiguration> VideoExtensions { get; set; }
        public List<PhotoExtension_CameraConfiguration> PhotoExtensions { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Active { get; set; }
        public List<MonitoringDetail> MonitoringDetails { get; set; }

        public override string ToString()
        {
            return CameraName;
        }
        #endregion



    }
}
