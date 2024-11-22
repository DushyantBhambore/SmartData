using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Approach.Data.Entities
{
    public class Master
    {
        [Key]
        public int masterId { get; set; }
        public Student? MStudent { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Courses? MCourse { get; set; }
        [ForeignKey(nameof(Courses))]
        public int CourseId { get; set; }
        public Instructors? MIntrusctor { get; set; }
        [ForeignKey(nameof(Instructors))]
        public int InstructorId { get; set; }

    }
}
