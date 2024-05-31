using BE_ABC.ConstValue;

namespace BE_ABC.Models.DTO.Request
{
    public class ResourceCreateReq
    {
        public string resourceTypeId { get; set; }
        public string name { get; set; }
        public List<string> images { get; set; }
        public string description { get; set; }
        public bool isFree { get; set; }
        public StatusType status { get; set; }
    }
    public class ResourceReq
    {
        public int id { get; set; }
        public string resourceTypeId { get; set; }
        public string name { get; set; }
        public List<string> images { get; set; }
        public string description { get; set; }
        public bool isFree { get; set; }
        public StatusType status { get; set; }
    }
}
