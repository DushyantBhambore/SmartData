using Code_First_Approach.Data;
using Code_First_Approach.Data.Entities;
using Code_First_Approach.Interfaces;

namespace Code_First_Approach.Services
{
    public class InstructorServices : Iinstructor
    {
        private readonly ApplicationDbContext dbContext;

        public InstructorServices(ApplicationDbContext _dbContext )
        {
            dbContext = _dbContext;
        }
        public void AddInstructors(Instructors model)
        {
            dbContext.instructors.Add( model );
            //dbContext.instructors.Add(new Instructors
            //{
            //    Inrstructor_Id = model.Inrstructor_Id,
            //    Instructor_Name = model.Instructor_Name,
            //    Courses = model.Courses,
            //    Student = model.Student
            //});
            dbContext.SaveChanges();
        }

        public List<Instructors> instructorsList()
        {
            List<Instructors> newlist = new List<Instructors>();
            var obj = dbContext.instructors.ToList();

            foreach (var item in obj) 
            {
                newlist.Add(new Instructors
                {
                    Inrstructor_Id = item.Inrstructor_Id,
                    Instructor_Name = item.Instructor_Name,
                    //StudentId  =item.StudentId,
                    //CourseId =item.CourseId,
                    Courses = item.Courses,
                    Student = item.Student,
                });
            }
            return newlist;
        }
    }
}
