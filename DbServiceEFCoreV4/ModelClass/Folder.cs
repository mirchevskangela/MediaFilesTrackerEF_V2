using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string FolderPath { get; set; }
        public List<Folder_CameraConfiguration> Folder_CameraConfiguration { get; set; }
        public List<Folder_ConfigurationModificationDetail> Folder_ConfigurationModificationDetail { get; set; }
        public override string ToString()
        {
            return FolderPath;
        }

    }
}
