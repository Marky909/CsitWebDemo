using CsitWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CsitWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Name = "Mark";
            ViewBag.College = "Tribhuvan University";
            ViewBag.Age = 20;
            return View();
        }

        public IActionResult Contact()
        {
            StudentModel student = new StudentModel
            {
                Name = "Mark",
                Age = 20,
                Email = "mark@gmail.com"
            };

            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
