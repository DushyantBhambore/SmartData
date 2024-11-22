using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.AnonymousType
{
    internal class AnonymousExample
    {
        public static void Test()
        {
            var message = new
            {
                Name = "Bill",
                Age = 20,
            };
            Console.WriteLine($"Name is = {message.Name} and Age is {message.Age}");

            //var Employee = new 
            //{

            //}
        }
    }
}
