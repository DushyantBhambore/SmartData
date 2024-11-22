using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
public static class ShowExtension1
    {
        public static int CollegeAge(Student student)
        {
            return DateTime.Today.Year-student.DateofBirth.Year;
        }
    }
}
