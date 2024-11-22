using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLecture._09_09_24
{
    public class Student
    {
        public delegate void Mydelegate1();
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get 
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public DateTime DateOfBirth { get; set; }

         public Student(DateTime dob)
        {
            StudentId = 0;
            DateOfBirth = dob;
        }

        public  void Show()
        {
            Console.WriteLine("he id is "+StudentId);
        }

        public static void Test()
        {
            Student std1 = new Student(DateTime.Now);

            std1.StudentId = 1;
            std1.StudentName = "A";
            std1.DateOfBirth = new DateTime(2000 - 09 - 09);
            
            Mydelegate1 myshow = std1.Show;


        }
    }
}
