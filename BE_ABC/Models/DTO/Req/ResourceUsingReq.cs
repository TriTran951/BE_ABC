using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.DTO.Request
{
    public class ResourceUsingReq
    {
        public int resourceId { get; set; }
        public string reporterUid { get; set; }
        public string borrowerUid { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public StatusType status { get; set; }
    }
}
