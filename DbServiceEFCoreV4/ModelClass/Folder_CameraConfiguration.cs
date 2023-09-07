using DbServiceEFCoreV4.ModelClass;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4
{
    public class Folder_CameraConfiguration
    {
        [Key]
        public int Id { get; set; }
        public int CameraConfigurationId { get; set; }
        public ClassLibrary.ModelClass.CameraConfiguration CameraConfiguration { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public override string ToString()
        {
            return Folder?.ToString();
        }
    }
}
