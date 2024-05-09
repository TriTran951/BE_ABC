using BE_ABC.ConstValue;

namespace BE_ABC.Models.DTO.Request
{
    public class UserReq
    {
        public string uid { get; set; }
        public int? departmentId { get; set; }
        public Grade? grade { get; set; }
        public string username { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string description { get; set; }
        public List<Grade>? permissionIdToCRUD { get; set; }
        public StatusType status { get; set; }
    }
}
