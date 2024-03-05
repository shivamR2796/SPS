using System.ComponentModel.DataAnnotations;

namespace SPS.Models
{
    public class Admin
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
