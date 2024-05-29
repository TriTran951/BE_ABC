using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class ResourceTypeReq
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Grade> permissionIdToCRUDResourceUsing { get; set; }
        public List<Grade> permissionIdToCRUDResource { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public StatusType status { get; set; }
    }
}
