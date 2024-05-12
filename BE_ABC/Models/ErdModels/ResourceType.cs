using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("ResourceType")]
    public class ResourceType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public List<Grade> permissionIdToCRUDResourceUsing { get; set; }
        public List<Grade> permissionIdToCRUDResource { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }

    }
}
