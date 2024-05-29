using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModel
{
    [Table("PostType")]
    public class PostType
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; } 
        public List<Grade> permissionIdToCRUDPost { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
    }
}
