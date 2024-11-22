using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH21_Exception_Handling
    {

        ///<summary>
        ///
        /// Exception : An exception which occurs during the execution of a program that disrupts the normal flow of the programs intructions 
        /// 
        /// In general when a c# code encounters a situation that it cannot with , it raises an exception
        /// 
        /// Exception  are abnormal events that prevent a certain task from being completed successfully 
        /// 
        /// An exception is a problem that arises during the execution of a problem 
        /// 
        /// Exception is a response to an exceptional circumstance that arises while a program is runnig, such as an attempt to divide by zero .
        /// 
        /// 
        /// **** Exception Handling 
        /// 
        /// The exception handling in c# is one of the powerful mechanism to handle the runtime errors so that normal flow of the appliaction can be maintained 
        /// </summary> 

        public static void Dividebyzeo()
        {
            Console.WriteLine("Enter first Number =");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second Number = ");
            int b = Convert.ToInt32(Console.ReadLine());

            try
            {
                var c = a / b;
                Console.WriteLine("Result is :" + c);
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(" Number canot divisible by zero ");
                Console.WriteLine(ex.Message);
            }
           
        }

        public static void ArrayOutOfBound()
        {
            int[] arr = new int[3];
            

            try
            {
                arr[0] = 11;
                arr[1] = 12;
                arr[2] = 13;
                arr[3] = 14;

                foreach (var i in arr)
                {
                    Console.WriteLine(i);
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("Array Lenght is ends ");
                Console.WriteLine(ex.Message);
            }
        }

        ///<summary>
        ///
        /// Null Reference Exception  : string variable you have enter the null value 
        /// 
        /// </summary>
        /// 

        public static void NullreferenceException()
        {
            try
            {
                string? name = null;
                Console.WriteLine(name.Length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("String is null");
                Console.WriteLine(ex.Message);
            }

        }

        // Formate Exception : String varable is converted into integer variable 

        // error : System.FormatException: 'The input string 'Dushyant' was not in a correct format.'

        public static void FormatException()
        {
            Console.WriteLine("Enter a number = ");
            var number = Console.ReadLine();
            try
            {
                int a = int.Parse(number);
                Console.WriteLine("Your Number is =" + a);
            }
            catch(FormatException ex)
            {
                Console.WriteLine("You have enter the string value it cannot istead integer ");
                Console.WriteLine(ex.Message);
            }
            
        }

        // Exception Class and its use 
        // Exception is parent class of the other execeptions

        public static void ExceptionClass()
        {
            //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
            //int[] arr = new int[3];
            //arr[0] = 11;
            //arr[1] = 12;
            //arr[2] = 13;
            //arr[3] = 14;


            //Attempted to divide by zero.
            //Console.WriteLine("Enter the first number =");
            //int a = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the second number =");
            //int b = int.Parse(Console.ReadLine());
      
            
            //The input string 'Dushyant ' was not in a correct format
            Console.WriteLine("Enter a numnber = ");
            string number = Console.ReadLine();

            try
            {
                int a = int.Parse(number);
                Console.WriteLine("Your entered number is : "+a);

                //int c = a / b;
                //Console.WriteLine("Result is :"+c);
                //foreach(var i in arr)
                //{
                //    Console.WriteLine(i);
                //}
                //string name = null;
                //Console.WriteLine(name.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
