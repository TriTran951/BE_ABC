﻿using BE_ABC.ConstValue;
using BE_ABC.Models.ErdModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_ABC.Models.ErdModels
{
    [Table("RequestType")]
    public class RequestType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int approvalDepartmentId { get; set; }
        public Grade minApprovalGrade { get; set; }
        public List<Grade> permissionIdToCRUD { get; set; }
        public int createAt { get; set; }
        public int updateAt { get; set; }
        public StatusType status { get; set; }
        public Department Department { get; set; }
        public ICollection<Request> Request {  get; set; }
    }
}
