using Microsoft.EntityFrameworkCore;
using Student_without_interface.Data;
using Student_without_interface.Model;

namespace Student_without_interface.StudentServices
{
    public class StudentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StudentRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Student>> GetAllStudent()
        {
            return await dbContext.students.ToListAsync();
        }

        public async Task GetStudent(Student student)
        {
            await dbContext.students.AddAsync(student);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var obj = await dbContext.students.FindAsync(id);

            if (obj is not null)
            {
                Student student = new()
                {
                    Name = obj.Name,
                    Age = obj.Age,
                    City = obj.City,
                    Address = obj.Address,
                    DateOfBirth = obj.DateOfBirth,
                };
                return student;
            }
            return null;
        }

        public async Task UpdateStudentByAsync(Student student)
        {
            var obj = await dbContext.students.FindAsync(student.StudentId);

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


        public async Task DeleteStudentBYAsync(int id)
        {
            var obj = await dbContext.students.FindAsync(id);

            if (obj is not null)
            {
                dbContext.students.Remove(obj);
                dbContext.SaveChanges();
            }
        }

    }
}
