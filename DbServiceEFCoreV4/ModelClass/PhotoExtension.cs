using DbServiceEFCoreV4.DbServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class PhotoExtension
    {
        [Key]
        public int Id { get; set; }
        public string Extension { get; set; }
        public List<PhotoExtension_CameraConfiguration> PhotoExtension_CameraConfiguration { get; set; }
        public List<PhotoExtension_ConfigurationModificationDetail> PhotoExtension_ConfigurationModificationDetail { get; set; }
        public override string ToString()
        {
            return Extension;
        }

    }
}
