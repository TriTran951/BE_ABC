using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModels
{

    [Table("Request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string requesterUid { get; set; }
        public string requestType { get; set; }
        public string reporterUid { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public int decidedAt { get; set; }
        [Column(TypeName = "text")]
        public string? decisionDetail { get; set; }
        [JsonIgnore]
        public int createAt { get; set; }
        [JsonIgnore]
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("requesterUid")]
        [JsonIgnore]
        public User Requester { get; set; }
        [ForeignKey("reporterUid")]
        [JsonIgnore]
        public User Reporter { get; set; }
        [ForeignKey("requestType")]
        [JsonIgnore]
        public RequestType RequestType { get; set; }
    }
}
