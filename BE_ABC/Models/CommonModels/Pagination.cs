using System.ComponentModel.DataAnnotations;

namespace BE_ABC.Models.CommonModels
{
    public class Pagination
    {
        [Required]
        public int page { get; set; }
        [Required]
        public int limit { get; set; }
    }
}
