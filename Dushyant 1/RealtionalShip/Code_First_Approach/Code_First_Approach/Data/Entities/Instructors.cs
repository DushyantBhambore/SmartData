using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Approach.Data.Entities
{
    public class Instructors
    {
        [Key]
        public int Inrstructor_Id { get; set; }
        public string? Instructor_Name { get; set; }

        public ICollection<Student>? Students { get; set; }

        public List<Student>? Student { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public List<Courses>? Courses { get; set; }
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
    }
}
