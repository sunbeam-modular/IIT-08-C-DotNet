using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace validationDemo.Models
{
    [Table("VDCourse")]
    public class Course
    {
        
        public int CourseId { get; set; }

        
            public string CourseName { get; set; }
            public List<Student> Students { get; set; }
        }
    }

