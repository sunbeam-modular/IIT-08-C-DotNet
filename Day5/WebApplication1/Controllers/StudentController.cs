using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        SbContext sb = new SbContext();
        public IActionResult Index()
        {
            return View();

           
        }

        public IActionResult Create()
        {

           
            return View(sb.Courses.ToList());
        }

        public IActionResult AfterCreate(int id, Student s)
        {
            Course c = sb.Courses.Find(id);
            sb.Students.Add(s);
            sb.SaveChanges();



            
            // sb.Courses.Update(c);
            return Redirect("Index");
        }

                

            
        }
    }

