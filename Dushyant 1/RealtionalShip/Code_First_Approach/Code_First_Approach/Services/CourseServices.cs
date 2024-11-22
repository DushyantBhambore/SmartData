using Code_First_Approach.Data;
using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;

namespace Code_First_Approach.Services
{
    public class CourseServices : ICourses
    {
        private readonly ApplicationDbContext dbContext;

        public CourseServices(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        
        public void AddCourse(Courses model)
        {
            dbContext.courses.Add(new Courses
            {
                CourseId = model.CourseId,
                Course_Name = model.Course_Name,
            });
            dbContext.SaveChanges();
        }

        public List<Courses> CourseList()
        {
            List<Courses> newcourses = new();
            var obj = dbContext.courses.ToList();
            foreach (var course in obj) 
            {
                newcourses.Add(new Courses
                {
                    CourseId = course.CourseId,
                    Course_Name = course.Course_Name,
                    //StudentId = course.StudentId,
                    //Student = course.Student,
                });
            }
            return newcourses;
        }

    }
}
