using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.DTO.Request
{
    public class DepartmentReq
    {
        public string id { get; set; }
        public string directorUid { get; set; }
        public string name { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public StatusType status { get; set; }

    }

}
