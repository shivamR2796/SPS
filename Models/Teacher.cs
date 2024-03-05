using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPS.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Contect { get; set; }
        [Required]
        public string Alter_Contect { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public DateTime? Join_Date { get; set; }


        public string? January { get; set; }
     
        public string? February { get; set; }
       
        public string? March { get; set; }
       
        public string? April { get; set; }
      
        public string? May { get; set; }
       
        public string? June { get; set; }
       
        public string? July { get; set; }
       
        public string? August { get; set; }
    
        public string? September { get; set; }
      
        public string? October { get; set; }
       
        public string? November { get; set; }
      
        public string? December { get; set; }
    }
}
