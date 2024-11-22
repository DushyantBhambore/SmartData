using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLecture._09_09_24.Anonymous
{
    internal class AnonymousExample
    {
        public static void Example()
        {
            var test = new
            {
                Name = "Test",
                Age = 23,
                Id =1   
            };
            Console.WriteLine(test);
        }
    }
}
