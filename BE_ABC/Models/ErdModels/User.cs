using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("User")]
    public class User
    {
        [Key]
        public string uid { get; set; }
        public int departmentId { get; set; }
        public Grade grade { get; set; }
        public string username { get; set; }
        public DateTime birthday { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("departmentId")]
        public Department Department { get; set; }
        public virtual ICollection<PostLike> PostLike { get; set; }
        public virtual ICollection<PostComment> PostComment { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Document> Document { get; set; }
    }
}
