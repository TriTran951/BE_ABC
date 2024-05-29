using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("EventType")]
    public class EventType
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        [Column(TypeName = "text")]
        public string description { get; set; }
        public List<Grade> permissionIdToCRUDEvent { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        public ICollection<Event> Event { get; set; }  
    }
}
