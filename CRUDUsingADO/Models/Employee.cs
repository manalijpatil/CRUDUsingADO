using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [Display(Name="Employee Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name="Email Id")]
        public string? Email {  get; set; }
        [Required]
        [Display(Name="Enter Salary")]
        public double Salary {  get; set; }

    }
}
