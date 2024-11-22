using Microsoft.EntityFrameworkCore;
using Student_without_interface.Data;
using Student_without_interface.Model;

namespace Student_without_interface.StudentServices
{
    public class StudentServices : IStudentServices
    {
        private readonly ApplicationDbContext dbContext;

        public StudentServices(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public void AdddStudent(Student student)
        {
            dbContext.students.Add(new Model.Student
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Age = student.Age,
                City = student.City,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth,
            });
            dbContext.SaveChanges();
        }

        public List<Student> StudentList()
        {
            List<Student> newList = new List<Student>();
            var list = dbContext.students.ToList();

            foreach (var student in list)
            {
                newList.Add(new Student
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Age = student.Age,
                    City = student.City,
                    Address = student.Address,
                    DateOfBirth = DateTime.Now,

                });
            }
            return newList;

        }

        public Student GetStudentById(int id)
        {
            var obj = dbContext.students.Find(id);

            if (obj is not null)
            {
                Student mdel = new()
                {
                    Name = obj.Name,
                    Age = obj.Age,
                    City = obj.City,
                    Address = obj.Address,
                    DateOfBirth = obj.DateOfBirth,
                };
                return mdel;
            }
            return null;

        }

        public void UpdateStudent(Student student)
        {
            var obj = dbContext.students.Find(student.StudentId);

            if (obj is not null)
            {
                obj.Name = student.Name;
                obj.Age = student.Age;
                obj.City = student.City;
                obj.Address = student.Address;
                obj.DateOfBirth = student.DateOfBirth;
                dbContext.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var obj = dbContext.students.Find(id);
            if (obj is not null)
            {
                dbContext.students.Remove(obj);
                dbContext.SaveChanges();

            }
        }

       
    }
}
