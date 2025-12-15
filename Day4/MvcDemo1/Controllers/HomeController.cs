using Microsoft.AspNetCore.Mvc;
using MvcDemo1.Models;
using System.Diagnostics;

namespace MvcDemo1.Controllers
{
    public class HomeController : Controller
    {

        SbContext sb = new SbContext();
       
        public IActionResult Index()
        {
          List<Student> slist=  sb.Students.ToList();

            return View(slist);   //Views/Home/Inde.cshtml=List
        }

        public IActionResult Create()
        {
            return View(); //Views/Home/Create.cshtml
        }

        public IActionResult AfterCreate(Student s)
        {
            sb.Students.Add(s);
            sb.SaveChanges();
            return Redirect("/Home/Index"); 
        }

        public IActionResult Edit(int id)
        {

            Student s1=sb.Students.Find(id);
            return View(s1); //Views/Home/Edit.cshtml
        }

        public IActionResult AfterEdit(Student s)
        {

            Student s1 = sb.Students.Find(s.Id);
            s1.Name = s.Name;
            s1.CourseName = s.CourseName;
            sb.SaveChanges();

            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int id)
        {

            Student s1 = sb.Students.Find(id);
            sb.Students.Remove(s1);
            sb.SaveChanges();

            return Redirect("/Home/Index");
        }


    }
}
