using ClassLibrary.ModelClass;
using DbServiceEFCoreV4.ModelClass;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.DbServices
{
    public class PhotoExtension_ConfigurationModificationDetail
    {
        [Key]
        public int Id { get; set; }
        public PhotoExtension PhotoExtension { get; set; }
        public int PhotoExtensionId { get; set; }
        public ConfigurationModificationDetail ConfigurationModificationDetail { get; set; }
        public int ConfigurationModificationDetailId { get; set; }
        public override string ToString()
        {
            return PhotoExtension.ToString();
        }
    }
}
