using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace C_PracticethroughMicrosoft.Delegate
{
    public delegate void ShowDelegate();

    internal class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Today.Year - DateOfBirth.Year;
            }
               
         }



        public static void Delegate()
        {
            Student student = new Student();
            student.StudentName = "Test 2";
            student.StudentId = 2;
            student.DateOfBirth = DateTime.Today;
            // first object
            ShowDelegate show = student.Show;
            show();

            var student2 = new Student
            {
                StudentId = 10,
                DateOfBirth = new DateTime(2003, 01, 09),
                StudentName = "Test 3"
            };
            show += student2.Show;
            show();

        }

        public void Show()
        {
            Console.WriteLine("My Id is "+StudentId);
        }
    }
}
