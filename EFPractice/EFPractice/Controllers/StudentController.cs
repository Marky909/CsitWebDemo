using EFPractice.Data;
using Microsoft.AspNetCore.Mvc;

namespace EFPractice.Controllers
{
    public class StudentController : Controller
    {
        public  EFPracticeContext _context;

        public StudentController(EFPracticeContext context)
        {
            _context = context;
        }

        public IActionResult StudentList()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
        public IActionResult CreateStudent()
        {

            return View();
        }

        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public IActionResult Delete(int id)
        {
            Student student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("StudentList");

        }
    }
}
