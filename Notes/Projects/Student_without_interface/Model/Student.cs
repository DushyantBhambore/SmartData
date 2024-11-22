using System.ComponentModel.DataAnnotations;

namespace Student_without_interface.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
