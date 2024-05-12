using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModel
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int postTypeId { get; set; }
        public string creatorUid { get; set; }
        public int? eventId { get; set; }
        public string[] mentionUid {  get; set; }
        public string title { get; set; }
        [Column(TypeName = "text")]
        public string content {  get; set; }
        public List<string> images {  get; set; }
        public List<string> files { get; set; }
        public int likes {  get; set; }
        public int comments {  get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        public virtual ICollection<PostLike> PostLike { get; set; }
        public virtual ICollection<PostComment> PostComment { get; set; }
        [ForeignKey("postTypeId")]
        public PostType PostType { get; set; }
        [ForeignKey("creatorUid")]
        public User User { get; set; }
        [ForeignKey("eventId")]
        public Event Event { get; set; }
    }
}
