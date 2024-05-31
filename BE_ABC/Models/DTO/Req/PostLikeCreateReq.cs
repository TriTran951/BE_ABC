using BE_ABC.ConstValue;

namespace BE_ABC.Models.DTO.Request
{
    public class PostLikeCreateReq
    {
        public string userId { get; set; }
        public int postId { get; set; }
        public StatusType status { get; set; }

    }
    public class PostLikeReq
    {
        public int id { get; set; }
        public string userId { get; set; }
        public int postId { get; set; }
        public StatusType status { get; set; }

    }
}
