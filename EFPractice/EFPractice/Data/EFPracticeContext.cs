using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPractice.Data
{
    public class EFPracticeContext:DbContext
    {
        public EFPracticeContext(DbContextOptions<EFPracticeContext> options):base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentMark> StudentMarks { get; set; }
    }
    [Table("Student")]
    public class Student
    {
        [Key]
        public  int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = "";

        public ICollection<StudentMark> Marks { get; set; }
    }
    [Table("StudentMark")]
    public class StudentMark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [Range(0,100)]
        public int ObtainedMark { get; set; }

    }
}
