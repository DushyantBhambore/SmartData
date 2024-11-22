using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Delegates
{
    /// <summary>
    /// Delegates 
    /// </summary>

    
    internal class DelegateExample
    {
       public delegate void Mydelegate();
        public delegate void Valuedelegate(int num1, int num2);
        public delegate void MultipleDelegate(int num);
        public delegate void MessageDelegate(string message);


        public static void MyFunction()
        {
            Console.WriteLine("Hello delegate");
        }

        public  static int Add(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }

        // Multiple Delegates 
        public static void Cube(int num)
        {
            int result = num * num * num;
            Console.WriteLine($"Cube is ={result}");
        }
        public static void Table(int num )
        {
            for( int i=1;i<=10;i++)
            {
                int result = i * num;
                Console.WriteLine($"Table of {num} * {i} is {result}");
            }
        }


        //Multicast Delegates
        public static void Addition(int num1 , int num2)
        {
            int result = num1 + num2;
            Console.WriteLine($"Addition is {result}");
        }

        public static void Subtration(int num1 , int num2)
        {
            
            int result = num1 - num2;
            Console.WriteLine($"Subtraction is {result}");

        }

        public static void Multiplication(int num1 , int num2)
        {
            int result = num1 * num2;
            Console.WriteLine($"Multiplication is {result}");

        }

        public static void Division(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine($"Division is {result}");

        }

        public static void Modulo(int num1, int num2)
        {
            
                int result = num1 % num2;
                Console.WriteLine($"Modulo is {result}");
            
        }

        public static void Hello(string s)
        {
            Console.WriteLine($"Hello {s}");
        }
         
        public static void Goodbye(string s)
        {
            Console.WriteLine($"Goodbye {s}");
        }
    }
}
