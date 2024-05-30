using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.DTO.insertReq
{
    public class SearchReq
    {
        [Required]
        public int page { get; set; }
        [Required]
        public int limit { get; set; }
        public string text { get; set; }
    }
}
