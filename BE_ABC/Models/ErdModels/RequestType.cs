using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModels
{
    [Table("RequestType")]
    public class RequestType
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string approvalDepartmentId { get; set; }
        public Grade minApprovalGrade { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        [JsonIgnore]
        public int createAt { get; set; }
        [JsonIgnore]
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("approvalDepartmentId")]
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
