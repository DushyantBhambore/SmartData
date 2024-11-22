using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLecture._09_09_24.Practice
{
    public delegate void ShowDelegate();
    internal class Practice1
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static  void Test()
        {
            MyWork();
        }

        public int Age
        {
            get { return DateTime.Today.Year - DateOfBirth.Year; }
        }

        public void TestWork()
        {
            Practice1 obj = new Practice1();
            obj.StudentId = 1;
            obj.StudentName = "Abc";
            obj.DateOfBirth = new DateTime(1967, 07, 08);
            Console.WriteLine("Name is ="+obj.StudentName+"\n Student Id is ="+obj.StudentId+"\n Date Of Birth is ="+obj.DateOfBirth+"\n Age is "+obj.Age);

        }

        public static void MyWork()
        {
            Practice1 student = new Practice1();
            student.StudentId = 1;
            student.StudentName = "Bill";
            student.DateOfBirth = new DateTime(2000, 12, 31);

            ShowDelegate show = student.ShowFunction;

            var student2 = new Practice1
            {
                StudentId = 35,
                StudentName = "Tony",
                DateOfBirth = new  DateTime(2002,09,25),
                
            };
            show += student2.ShowFunction;
            show();
        }

        public  void ShowFunction()
        {
            Console.WriteLine("My Id is "+StudentId);
            Console.WriteLine("My Name is " + StudentName);
            Console.WriteLine("My Date Of Birth is " + DateOfBirth);
            Console.WriteLine("My Age is "+Age);
            
        }

    }
}
