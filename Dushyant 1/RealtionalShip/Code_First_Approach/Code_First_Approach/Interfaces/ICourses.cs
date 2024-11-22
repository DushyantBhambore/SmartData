using Code_First_Approach.Data.Entities;

namespace Code_First_Approach.Interfaces
{
    public interface ICourses
    {
        List<Courses> CourseList();

        void AddCourse(Courses courses);

    }
}
