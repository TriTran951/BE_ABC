using BE_ABC.ConstValue;

namespace BE_ABC.Models.DTO.Request
{
    public class PostCommentCreateReq
    {
        public string userId { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public List<string> images { get; set; }
        public List<string> file { get; set; }
        public StatusType status { get; set; }
    }
    public class PostCommentReq
    {
        public int id { get; set; }
        public string userId { get; set; }
        public int postId { get; set; }
        public string content { get; set; }
        public List<string> images { get; set; }
        public List<string> file { get; set; }
        public StatusType status { get; set; }
    }
}
