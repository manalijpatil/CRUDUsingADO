using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Student
    {
        [Key]
        public int StudId { get; set; }
        [Required]
        [Display(Name ="Enter student name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Enter Branch")]
        public string? Branch {  get; set; }
        [Required]
        [Display(Name = "Enter Percentage")]
        public double Percentage {  get; set; }
    }
}
