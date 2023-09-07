using DbServiceEFCoreV4.DbServices;
using DbServiceEFCoreV4.ModelClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.ModelClass
{
    public class ConfigurationModificationDetail
    {
        #region Members
        [System.ComponentModel.Browsable(false)]
        public int Id { get; set; }
        public string CameraName { get; set; }
        //  public string FolderPath { get; set; }
        public List<Folder_ConfigurationModificationDetail> Folders { get; set; }
        public List<VideoExtension_ConfigurationModificationDetail> VideoExtensions { get; set; }
        public List<PhotoExtension_ConfigurationModificationDetail> PhotoExtensions { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string VideoExtension
        {
            get
            {
                var VideoExtensionsStrings = VideoExtensions?.Select(x => x.VideoExtension?.ToString()).ToList();
                return string.Join(",", VideoExtensionsStrings);
            }
        }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string PhotoExtension
        {
            get
            {
                var photoExtensionsString = PhotoExtensions?.Select(x => x.PhotoExtension?.ToString()).ToList();
                return string.Join(",", photoExtensionsString);
            }
        }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string FoldersString
        {
            get
            {
                var folderString = Folders?.Select(x => x.Folder?.ToString()).ToList();
                return string.Join(",", folderString);
            }
        }
        [System.ComponentModel.Browsable(false)]
        public Actions Actions { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int ActionsID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string Action { get { return Actions?.Action; } }
        public String Item { get; set; }
        public DateTime Timestamp { get; set; }
        #endregion
    }
}
