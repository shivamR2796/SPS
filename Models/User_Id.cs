using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPS.Models
{
    public class User_Id
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string C_Password { get; set; }
    }
}
