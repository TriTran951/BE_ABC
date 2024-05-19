using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class UserReq
    {
        public string uid { get; set; }
        public string? departmentId { get; set; }
        public Grade? grade { get; set; }
        public string username { get; set; }
        public int birthday { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string description { get; set; }
        public List<Grade>? permissionIdToCRUD { get; set; }
        [Range(0, 2)]
        public StatusType status { get; set; }
    }
}
