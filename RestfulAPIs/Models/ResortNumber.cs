using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPIs.Models
{
    public class ResortNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResortNo { get; set; }

        [ForeignKey("Resort")]
        public int ResortID { get; set; }

        public Resort Resort { get; set; }

        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
