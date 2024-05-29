using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class RequestTypeReq
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string approvalDepartmentId { get; set; }
        public Grade minApprovalGrade { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public StatusType status { get; set; }
    }
}
