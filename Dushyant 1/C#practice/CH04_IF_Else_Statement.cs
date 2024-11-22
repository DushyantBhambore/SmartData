using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH04_IF_Else_Statement
    {
        public static void If_Statement()
        {
            Console.Write("Enter a Number =");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a%2==0)
            {
                Console.WriteLine($"{a} is even ");
            }
        }
        public static void if_else_statement()
        {
            Console.Write("Enter a Number =");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a % 2 == 0)
            {
                Console.WriteLine($"{a} is even ");
            }
            else
            {
                Console.WriteLine($"{a} is odd");
            }
        }

        public static void If_Else_If_Statement()
        {
            Console.Write("Enter a Number =");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a%2==0)
            {
                Console.WriteLine($"{a} is even ");
            }
            else if(a%3==0)
            {
                Console.WriteLine($"{a} Number is Divisible by 3");
            }
            else
            {
                Console.WriteLine($"{a} Number is not Divisible by 3 and not even number ");
            }
        }
        public static void TernaryOperator()
        {
            Console.Write("Enter a age =");
            int a = Convert.ToInt32(Console.ReadLine());
            string result = (a >= 18) ? "You are eligible for vote" : "You are not eligible for vote";
            Console.WriteLine(result);
        }
    }
}
