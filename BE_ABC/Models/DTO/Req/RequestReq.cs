using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.DTO.Req
{
    public class RequestReq
    {
        public int id { get; set; }
        public string requesterUid { get; set; }
        public string requestTypeId { get; set; }
        public string reporterUid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public int decidedAt { get; set; }
        public string? decisionDetail { get; set; }
        public StatusType status { get; set; }
    }
    public class RequestCreateReq
    {
        public string requesterUid { get; set; }
        public string requestTypeId { get; set; }
        public string reporterUid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public int decidedAt { get; set; }
        public string? decisionDetail { get; set; }
        public StatusType status { get; set; }
    }
}
