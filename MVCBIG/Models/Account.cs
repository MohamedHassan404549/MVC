using System.ComponentModel.DataAnnotations;

namespace MVCBIG.Models
{
    public class Account
    {
        [Required]
        [Key]
        public string Name { get; set; }
        public int Password { get; set; }
    }
}
