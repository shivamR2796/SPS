using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPS.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Father_Name { get; set; }
        [Required]
        public string Mother_Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Contect { get; set; }
        [Required]
        public string Alter_Contect { get; set; }
        [Required]
        public DateTime? Addmission_Date { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Image { get; set; }


       
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
