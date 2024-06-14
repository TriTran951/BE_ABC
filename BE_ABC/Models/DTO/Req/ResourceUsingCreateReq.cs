using BE_ABC.ConstValue;

namespace BE_ABC.Models.DTO.Request
{
    public class ResourceUsingCreateReq
    {
        public int resourceId { get; set; }
        public string reporterUid { get; set; }
        public string borrowerUid { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public StatusType status { get; set; }
    }
    public class ResourceUsingReq
    {
        public int id { get; set; }
        public int resourceId { get; set; }
        public string reporterUid { get; set; }
        public string borrowerUid { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public StatusType status { get; set; }
    }

}
