using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBIG.Models
{
    public class Project
    {
        [Key]
        public int PNumber { get; set; }

        public string? PName { get; set; }

        public string? PLocation { get; set; }

        // Foreign key representing the Dnumber (Department Number)
        [ForeignKey("Department")]
        public int DNUM { get; set; }

        // Navigation property to represent the relationship with Department
        public virtual Department? Department { get; set; }

        // Collection navigation property to represent the relationship with Works_ON
        public virtual ICollection<Works_ON> Works_ON { get; set; } = new HashSet<Works_ON>();

    }
}
