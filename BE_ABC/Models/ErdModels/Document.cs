using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int documentTypeId { get; set; }
        public string creatorUid { get; set; }
        public string file { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("documentTypeId")]
        public DocumentType DocumentType { get; set; }
        [ForeignKey("creatorUid")]
        public User User { get; set; }
    }
}
