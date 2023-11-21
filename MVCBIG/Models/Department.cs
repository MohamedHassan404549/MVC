using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBIG.Models
{
    public class Department
    {
        [Key]
        public int Dnumber { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? DName { get; set; }

        

      

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public virtual ICollection<Dept_Loc> Locations { get; set; } = new HashSet<Dept_Loc>();

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}


