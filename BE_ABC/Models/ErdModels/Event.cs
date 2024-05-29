using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModels
{
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string eventTypeId { get; set; }
        public string reporterUid { get; set; }
        public List<int> resouceUsingId { get; set; }
        public List<int> postsId { get; set; }
        public List<string> paticipantsUid { get; set; }
        public List<Grade> permissionIdToCRUDPost { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [JsonIgnore]
        public virtual ICollection<Post> Post { get; set; }
        [ForeignKey("reporterUid")]
        [JsonIgnore]
        public User User { get; set; }
        [ForeignKey("eventTypeId")]
        [JsonIgnore]
        public EventType EventType { get; set; }
        //[ForeignKey("resouceUsingId")]
        //public ResourceUsing ResourceUsing { get; set; }
    }
}
