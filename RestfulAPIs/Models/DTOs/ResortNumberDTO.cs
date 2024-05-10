using System.ComponentModel.DataAnnotations;

namespace RestfulAPIs.Models.DTOs
{
    public class ResortNumberDTO
    {
        [Required]
        public int ResortNo { get; set; }
        [Required]
        public int ResortID { get; set; }
        public string SpecialDetails { get; set; }
        public ResortDTO Resort { get; set; }
    }
}
