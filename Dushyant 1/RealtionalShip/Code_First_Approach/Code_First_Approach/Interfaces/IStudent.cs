using Code_First_Approach.Data.Entities;

namespace Code_First_Approach.Interfaces
{
    public interface IStudent
    {
        List<Student> GetAllStudent();

        void AddStudent (Student student);
    }
}
