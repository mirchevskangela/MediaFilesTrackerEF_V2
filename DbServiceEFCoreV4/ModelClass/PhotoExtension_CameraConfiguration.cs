using ClassLibrary.ModelClass;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class PhotoExtension_CameraConfiguration
    {
        [Key]
        public int Id { get; set; }
        public int CameraConfigurationId { get; set; }
        public CameraConfiguration CameraConfiguration { get; set; }
        public int PhotoExtensionId { get; set; }
        public PhotoExtension PhotoExtension { get; set; }
        public override string ToString()
        {
            return PhotoExtension?.ToString();
        }
    }
}
