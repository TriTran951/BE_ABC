using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModel
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string postTypeId { get; set; }
        public string creatorUid { get; set; }
        public int? eventId { get; set; }
        public List<string> mentionUid {  get; set; }
        public string title { get; set; }
        [Column(TypeName = "text")]
        public string content {  get; set; }
        public List<string> images {  get; set; }
        public List<string> files { get; set; }
        public int likes {  get; set; }
        public int comments {  get; set; }
        [JsonIgnore]
        public int createAt { get; set; }
        [JsonIgnore]
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("postTypeId")]
        [JsonIgnore]
        public PostType PostType { get; set; }
        [ForeignKey("creatorUid")]
        [JsonIgnore]
        public User User { get; set; }
        [ForeignKey("eventId")]
        [JsonIgnore]
        public Event Event { get; set; }
    }
}
