using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Collection
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get
            {
                return DateTime.Today.Year - DateOfBirth.Year;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public Student(DateTime dob)
        {
            DateOfBirth = dob;
          //  Age = DateTime.Today.Year - DateOfBirth.Year;
        }

        public void Show()
        {
            Console.WriteLine("My id is "+StudentId);
        }

    }
}
