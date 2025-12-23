using Microsoft.AspNetCore.Mvc;
using validationDemo.Models;

namespace ExceptionDemo.Controllers
{
    public class StudentController : Controller
    {

        private static List<Student> students = new()
    {
        new Student { Id = 1, Name = "Rahul", Email = "rahul@gmail.com", CourseId = 101 }
    };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

           
            if (student == null)
                throw new StudentNotFoundException("Student record not found.");

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            students.Add(student);
            return RedirectToAction("Index");
        }
        public IActionResult TestError()
        {
            // Any unexpected exception
            throw new Exception("Something broke!");
        }
    }
}
