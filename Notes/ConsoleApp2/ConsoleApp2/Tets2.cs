using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Tets2
    {
        public static void Testex()
        {
            Console.WriteLine("Enter 1st Number");
            int number1 = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine("Enter 2nd Number");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 3rd Number");
            int number3 = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter 4th Number");
            int number4 = Convert.ToInt32(Console.ReadLine());

            if (number1 > number2)
            {
                if (number1 > number3)
                {
                    if (number1 > number4)
                    {
                        Console.WriteLine($"number {number1} is greatest");
                    }
                }
            }
            else if (number2 > number3)
            {
                if (number2 > number4)
                {
                    Console.WriteLine($"Number {number2} is greatest");
                }
            }
            else
             if(number3 > number4)
            {
                Console.WriteLine($"Number {number3} is greatest");
            }
            else
            {
                Console.WriteLine($"Number {number4} is greatest");
            }
        }
    }
}
