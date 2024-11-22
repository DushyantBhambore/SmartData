using Student_without_interface.Model;

namespace Student_without_interface.StudentServices
{
    public interface IStudentServices
    {
        void AdddStudent(Student student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> StudentList();
        void UpdateStudent(Student student);
    }
}