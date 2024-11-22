using DailyLecture._09_09_24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLecture._11_09_24
{
    public static class StudentExtension
    {
        // before using this keyword we have call this method by its class
        // After using this keyword we have call by extension method
        public static int CalculateAge(this Student student)
        {
            return DateTime.Today.Year - student.DateOfBirth.Year;
        }
        public static int CalculateAge(this Student student, DateTime Dob)
        {
            Console.WriteLine("Date is "+Dob);
            return (DateTime.Today.Year-student.DateOfBirth.Year);
        }
    }
}
