using Code_First_Approach.Data;
using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;

namespace Code_First_Approach.Services
{
    public class StudentServices : IStudent
    {
        private readonly ApplicationDbContext dbContext;

        public StudentServices(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void AddStudent(Student student)
        {
            dbContext.students.Add(new Student
            {
                StudentId = student.StudentId,
                Student_Name= student.Student_Name,
                Age = student.Age,
                CourseId = student.CourseId,
                InstructorId = student.InstructorId,
                Email = student.Email,
            });
            dbContext.SaveChanges();
        }

        public List<Student> GetAllStudent()
        {
            List<Student> newlist = new List<Student>();
            var obj = dbContext.students.ToList();
            //foreach (var item in obj)
            //{
            //    newlist.Add(new Student
            //    {
            //        StudentId = item.StudentId,
            //        Student_Name = item.Student_Name,
            //        Email = item.Email,
            //        Age = item.Age,
            //        CourseId = item.CourseId,
            //        InstructorId = item.InstructorId,
            //    });

            //}
            return obj;
        }
    }
}
