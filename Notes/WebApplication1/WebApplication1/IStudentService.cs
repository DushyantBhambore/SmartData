using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        void PostStudent(Student student);
        // retutrn type--- Method name (id)
    }
}
