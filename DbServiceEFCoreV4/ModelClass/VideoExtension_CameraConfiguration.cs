using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class VideoExtension_CameraConfiguration
    {
        [Key]
        public int Id { get; set; }
        public int CameraConfigurationId { get; set; }
        public ClassLibrary.ModelClass.CameraConfiguration CameraConfiguration { get; set; }
        public int VideoExtensionId { get; set; }
        public VideoExtension VideoExtension { get; set; }
        public override string ToString()
        {
            return VideoExtension?.ToString();
        }

    }
}
