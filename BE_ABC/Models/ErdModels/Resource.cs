using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModel
{
    [Table("Resource")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string resourceTypeId { get; set; }
        public List<string> images { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public bool isFree { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }

        [ForeignKey("resourceTypeId")]
        public ResourceType ResourceType { get; set; }
        public virtual ICollection<ResourceUsing> ResourceUsing { get; set; }
    }
}
