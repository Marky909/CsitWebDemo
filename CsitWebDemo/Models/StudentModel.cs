using System.ComponentModel;

namespace CsitWebDemo.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("AGE")]

        public int Age { get; set; }

        public string Email { get; set; } = string.Empty;
        public string College { get; set; } = string.Empty;

    }
}
