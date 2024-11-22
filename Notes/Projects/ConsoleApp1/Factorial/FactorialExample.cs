using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Factorial
{
    public class FactorialExample
    {
        public static void Test()
        {
            Console.WriteLine("Enter a Number =");
            var n =Convert.ToInt32(Console.ReadLine());
            int fact = 1;

            for(int i=1;i<=n;i++)
            {
                 fact = fact * i;
                
               
            }

            Console.WriteLine($"The Factorial of given number  {n} is {fact}");
            Console.WriteLine("Do you want to perfom again yes or no =");
            string? message = Console.ReadLine();

            if(message=="yes")
            {
                Test();
            }
            else
            {
                Console.WriteLine("Thank you !"); 
            }
        }
    }
}
