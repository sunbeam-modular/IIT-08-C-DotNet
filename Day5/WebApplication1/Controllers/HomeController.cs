using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        SbContext sb = new SbContext();
        public HomeController(ILogger<HomeController> logger)
        {
            
        }

        public IActionResult Index()
        {
            return View(sb.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AfterCreate(Student s)
        {
            sb.Students.Add(s);
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult Edit(int id)
        {
           
            
            return View(sb.Students.Find(id));
        }

        /*public IActionResult AfterEdit(Student s)
        {
            Student s1=sb.Students.Find(s.StudentId);
            s1.Name = s.Name;
            s1.Age = s.Age;
            sb.SaveChanges();


            return Redirect("/Home/Index");
        }*/



    }
}
