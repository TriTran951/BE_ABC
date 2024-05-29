using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class ResourceReq
    {
        public string resourceTypeId { get; set; }
        public string name { get; set; }
        public List<string> images { get; set; }
        public string description { get; set; }
        public bool isFree { get; set; }
        public StatusType status { get; set; }
    }
}
