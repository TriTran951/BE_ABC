using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModel
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public string id { get; set; }
        public string directorUid { get; set; }
        public string name {  get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        [JsonIgnore]
        public int createAt { get; set; }
        [JsonIgnore]
        public int updateAt { get; set; }
        public StatusType status { get; set; }

        [ForeignKey("directorUid")]
        [JsonIgnore]
        public User User { get; set; }
    }
}
