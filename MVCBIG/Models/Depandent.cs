using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MVCBIG.Models
{
    public class Depandent
    {
        [Key]
        [Column(Order = 1)]
        public int? ESSN { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20, MinimumLength = 2)]
        public string? DEPENDENTNAME { get; set; }

        public DateTime BDATA { get; set; }

        public string? RELATIONSHIP { get; set; }


        // Navigation property to represent the relationship with Employee
        public virtual Employee? Employee { get; set; }
    }
}
