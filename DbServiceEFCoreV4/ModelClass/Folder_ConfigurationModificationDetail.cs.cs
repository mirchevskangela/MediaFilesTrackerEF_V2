using ClassLibrary.ModelClass;
using System.ComponentModel.DataAnnotations;

namespace DbServiceEFCoreV4.ModelClass
{
    public class Folder_ConfigurationModificationDetail
    {
        [Key]
        public int Id { get; set; }
        public ConfigurationModificationDetail ConfigurationModificationDetail { get; set; }
        public int ConfigurationModificationDetailId { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public override string ToString()
        {
            return Folder?.ToString();
        }
    }
}
