using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Calculator
    {
        public static void test()
        {
            Console.WriteLine("Enter the First Number =");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Number =");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Option Do you want to perform (+,-,*,/,%) =");
            string op = Console.ReadLine();
            if (op == "+")
            {
                Addition(a, b);

            }
            else if (op == "-")
            {
                Subtraction(a, b);
            }
            else if (op == "*")
            {
                Multiplication(a, b);
            }
            else if (op == "/")
            {
                Division(a, b);
            }
            else if ((op == "%"))
            {
                Modulo(a, b);

            }
            else
            {
                Console.WriteLine("Invalid Operation");
            }
        }
        public static void Addition(int a , int b)
        {
            int c = a + b;
            Console.WriteLine($"Addition is {a} and {b} = {c}",c);
        }

        public static void Subtraction(int  a , int b)
        {
            int c = a- b;
            Console.WriteLine($"Subtraction is {a} and {b} = {c}",c);
        }

        public static void Multiplication(int a, int b)
        {
            int c = a * b;
            Console.WriteLine($"Multiplication is {a} and {b} =  {c}",c);
        }
        public static void Division(int a, int b)
        {
            int c = a / b;
            Console.WriteLine($"Division is {a} and {b} = {c}",c);
        }
        public static void Modulo(int a, int b)
        {
            int c = a % b;
            Console.WriteLine($"Modulo is {a} and {b} =  {c}",c);
        }



    }
}
