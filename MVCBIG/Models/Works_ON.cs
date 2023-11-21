using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBIG.Models
{
    [Table("Works_ONs")]
    public class Works_ON
    {
        [Key]
        [Column(Order = 1)]
        public int ESSN { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PNO { get; set; }
        public int Hours { get; set;}


        // Navigation properties to represent the relationships with Employee and Project
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }

    }
}
