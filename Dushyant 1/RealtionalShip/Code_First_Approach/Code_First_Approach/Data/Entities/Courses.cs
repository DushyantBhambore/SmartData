using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Approach.Data.Entities
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }
        public string? Course_Name { get; set; }
        public List<Student>? Student { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public ICollection<Student>? Students { get; set; }

        public ICollection<Instructors>? Instructors { get; set; }
    }
}
