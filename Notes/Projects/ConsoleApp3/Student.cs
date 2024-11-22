using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Student
    {
        public int studentId { get; set; }
        public string student_Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get { return DateTime.Today.Year - DOB.Year; }
                }

        public Student(DateTime dob)
        {
            studentId = 0;
            DOB = dob;
        }
        public static void Test()
        {
            var student2 = new Student(DateTime.Now)
            {
                studentId = 1,
                student_Name = "BAC",
                DOB =new  DateTime(1999 - 09 - 01)
            };
        }

    }
}
