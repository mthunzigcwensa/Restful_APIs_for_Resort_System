using System.ComponentModel.DataAnnotations;

namespace RestfulAPIs.Models.DTOs
{
    public class ResortNumberCreateDTO
    {
        [Required]
        public int ResortNo { get; set; }
        [Required]
        public int ResortID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
