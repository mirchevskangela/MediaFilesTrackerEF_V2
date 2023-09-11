using ClassLibrary.ModelClass;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class VideoExtension_ConfigurationModificationDetail
    {
        [Key]
        public int Id { get; set; }
        public VideoExtension VideoExtension { get; set; }
        public int VideoExtensionId { get; set; }
        public ConfigurationModificationDetail ConfigurationModificationDetail { get; set; }
        public int ConfigurationModificationDetailId { get; set; }
        public override string ToString()
        {
            return VideoExtension?.ToString();
        }
    }
}
