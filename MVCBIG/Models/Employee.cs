using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBIG.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "Use the String Char.")]
        public string? FullName { get; set; }

        public DateTime Date { get; set; }

        public string? Address { get; set; }

        [Range(0, 100000)]
        public int Salary { get; set; }

        [ForeignKey("SuperSSN")]
        public virtual Employee? Supervisor { get; set; }

        [ForeignKey("DeptID")]
        public int Dnumber { get; set; }
        public virtual Department? Department { get; set; }

        // Collection navigation property to represent the weak entity relationship with Dependents
        public virtual ICollection<Depandent> Dependents { get; set; } = new HashSet<Depandent>();

        // Collection navigation property to represent the relationship with Works_ON
        public virtual ICollection<Works_ON> Works_ON { get; set; } = new HashSet<Works_ON>();
    }
}
