using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.Request
{
    public class PostReq
    {
        public string postTypeId { get; set; }
        public string creatorUid { get; set; }
        public int? eventId { get; set; }
        public List<string> mentionUid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List<string>? images { get; set; }
        public List<string>? files { get; set; }
        [Range(0,2)]
        public StatusType status { get; set; }

    }
}
