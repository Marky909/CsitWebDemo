using CsitWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CsitWebDemo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult StudentInfo()
        {
            StudentModel model = new StudentModel(); // requires StudentModel to be defined
            model.Id = 100;
            model.Age = 26;
            model.Name = "Mark";
            model.Email = "@gmail.com";
            return View(model);
        }
        public IActionResult Students()
        {
            List<StudentModel> students = new List<StudentModel>();

            StudentModel model1 = new StudentModel(); // requires StudentModel to be defined
            model1.Id = 100;
            model1.Age = 26;
            model1.Name = "Mark";
            model1.Email = "@gmail.com";

            StudentModel model2 = new StudentModel(); // requires StudentModel to be defined
            model2.Id = 100;
            model2.Age = 26;
            model2.Name = "shark";
            model2.Email = "@gmail.com";

            StudentModel model3 = new StudentModel(); // requires StudentModel to be defined
            model3.Id = 100;
            model3.Age = 26;
            model3.Name = "Nims";
            model3.Email = "@gmail.com";

            students.Add(model1);
            students.Add(model2);
            students.Add(model3);

            return View(students);

        }
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentModel student)
        {
            student.College = "BMC";
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=BMC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            string sqlCommand = "Insert Into student (Name,Age,Email,College) Values ('"+student.Name+"',"+student.Age+",'"+student.Email+"','"+student.College+"')";
            connection.Open();
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("SelectStudents");
        }
        public IActionResult SelectStudents()
        {
            List<StudentModel> StdModel = new List<StudentModel>();
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=BMC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlCommand = "SELECT Id,Name, Age, Email,College FROM Student";
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader SR = command.ExecuteReader();
            while(SR.Read())
            {
                StudentModel std = new StudentModel();
                std.Id = Convert.ToInt32(SR["Id"]);
                std.Age = Convert.ToInt32(SR["Age"]);
                std.Name = Convert.ToString(SR["Name"]);
                std.Email = Convert.ToString(SR["Email"]);
                std.College = Convert.ToString(SR["College"]);

                StdModel.Add(std);
            }


            connection.Close();

            return View(StdModel);
            

        }
        public IActionResult Details(int id)
        {
            List<StudentModel> StdModel = new List<StudentModel>();

            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=BMC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlCommand = "SELECT Id,Name, Age, Email,College FROM Student";
            SqlCommand command = new SqlCommand(sqlCommand, connection);
            SqlDataReader SR = command.ExecuteReader();
            while (SR.Read())
            {
                StudentModel std = new StudentModel();
                std.Id = Convert.ToInt32(SR["Id"]);
                std.Age = Convert.ToInt32(SR["Age"]);
                std.Name = Convert.ToString(SR["Name"]);
                std.Email = Convert.ToString(SR["Email"]);
                std.College = Convert.ToString(SR["College"]);

                StdModel.Add(std);
            }


            connection.Close();

            var student = StdModel.Where(x => x.Id == id).FirstOrDefault();

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=BMC;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlCommand = "DELETE student WHERE id = " + id;
            SqlCommand command = new SqlCommand(sqlCommand, connection);


            command.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("SelectStudents");
        }
    }
}
