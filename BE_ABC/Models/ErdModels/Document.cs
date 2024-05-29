using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BE_ABC.Models.ErdModels
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string documentTypeId { get; set; }
        public string creatorUid { get; set; }
        public string file { get; set; }
        [JsonIgnore]
        public int createAt { get; set; }
        [JsonIgnore]
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("documentTypeId")]
        [JsonIgnore]
        public DocumentType DocumentType { get; set; }
        [ForeignKey("creatorUid")]
        [JsonIgnore]
        public User User { get; set; }
    }
}
