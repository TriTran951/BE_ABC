using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class PostTypeCreateReq
    {
        public string id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Grade> permissionIdToCRUDPost { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        [Range(0, 2)]
        public StatusType status { get; set; }

    }
    public class PostTypeReq
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Grade> permissionIdToCRUDPost { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        [Range(0, 2)]
        public StatusType status { get; set; }

    }
}
