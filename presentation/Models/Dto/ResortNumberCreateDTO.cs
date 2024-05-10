using System.ComponentModel.DataAnnotations;

namespace presentation.Models.Dto
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
