using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBIG.Models
{
    public class Dept_Loc
    {
        [Key]
        [Column(Order = 1)] // Specify the order of the composite key
        public int Dnumber { get; set; }

        [Key]
        [Column(Order = 2)] // Specify the order of the composite key
        public string? Location { get; set; }

        // Navigation property to represent the relationship with the Department
        public virtual Department? Department { get; set; }
    }
}

