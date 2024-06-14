using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("ResourceUsing")]
    public class ResourceUsing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int resourceId { get; set; }
        public string reporterUid { get; set; }
        public string borrowerUid { get; set; }
        public int startAt { get; set; }
        public int endAt { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        [DefaultValue(0)]
        public ApprovalStatus approvalStatus { get; set; }
        public StatusType status { get; set; }
        [ForeignKey("reporterUid")]
        public User Reporter { get; set; }
        [ForeignKey("borrowerUid")]
        public User Borrower { get; set; }
        [ForeignKey("resourceId")]
        public Resource Resource { get; set; }

    }
}
