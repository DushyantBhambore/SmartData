using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Numbers
    {
        public static void Test()
        {
            // get two number from user
            Console.WriteLine("Enter First Number =");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number =");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What do you want to perform press according sign (+,-,*,/,%) = ");
            string? num3 = Console.ReadLine();

            if (num3 == "+")
            {

                Console.WriteLine($"Addition Of Given Two = {num1 + num2}");
                
            }
            else if (num3 == "-")
            {
                Console.WriteLine($"Subtraction Of Given Two = {num1 - num2}");
            }
            else if (num3 == "*")
            {
                Console.WriteLine($"Multiplication Of Given Two = {num1 * num2}");
            }
            else if (num3 == "/")
            {
                Console.WriteLine($"Division Of Given Two = {num1 / num2}");
            }
            else if (num3 == "%")
            {
                Console.WriteLine($"Modulo Of Given Two = {num1 % num2}");
            }
            else
            {
                Console.WriteLine("Invalid Operation ");
            }
        }
    }


}
