using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class VideoExtension
    {
        [Key]
        public int Id { get; set; }
        public string Extension { get; set; }
        public List<VideoExtension_CameraConfiguration> VideoExtension_CameraConfiguration { get; set; }
        public List<VideoExtension_ConfigurationModificationDetail> VideoExtension_ConfigurationModificationDetail { get; set; }

        public override string ToString()
        {
            return Extension;
        }
    }
}
