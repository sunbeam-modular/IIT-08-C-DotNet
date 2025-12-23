using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("VDStudent")]
    public class Student
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50,ErrorMessage ="Name cannot exceed 50 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Course selection is required")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }

}
