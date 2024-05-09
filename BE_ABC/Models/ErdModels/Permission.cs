using BE_ABC.ConstValue;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Action = BE_ABC.ConstValue.Action;

namespace BE_ABC.Models.ErdModels
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Grade minGrade { get; set; }
        public Action action { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public bool isPretected { get; set; }
        public StatusType status { get; set; }

    }
}
