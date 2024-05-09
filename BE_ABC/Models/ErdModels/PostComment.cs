using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModel
{
    [Table("PostComment")]
    public class PostComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string userId { get; set; }
        public int postId { get; set; }
        [Column(TypeName = "text")]
        public string content { get; set; }
        public List<Files> images { get; set; }
        public List<Files> file { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("postId")]   
        public Post Post { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }
    }
}
