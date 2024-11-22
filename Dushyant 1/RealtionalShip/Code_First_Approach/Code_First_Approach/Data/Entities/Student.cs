using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Approach.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Student_Name { get; set; }

        public string? Email { get; set; }

        public int Age { get; set; }

        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public int InstructorId { get; set; }


        public ICollection<Courses>? Courses { get; set; }
        public ICollection<Instructors>? Instructors { get; set; }

    } 
}
