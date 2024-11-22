using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public delegate void HelloDelegate(string message);

    public delegate void Calculation(int num1, int num2);

    public delegate void MyDelegates(int num);

    public delegate void MyMultiCastDelegate(int num1 , int num2);

    class CH17_Delegates
    {

        ///<summary>
        ///
        /// Delegate is a pointer to   function/methods  
        /// That is it hold a reference (pointer ) to a function 
        /// 
        /// ** Single Cast Delegates:
        /// 
        /// Singlecasr delegate point to single method at a time . In this the delegates is assigned to a single method at a time . They are derived from System.Delegate class
        /// 
        /// ** Multiple Delegates 
        /// In C# a user can invoke multiple delegates which a single program Dependig on the delegate name or the type  of parameter passed to the delegate, the appropriate delegate is invoked 
        /// 
        /// 
        /// ** Multi Cast Delegates 
        /// 
        /// When a delegate is wrapped with more than one method that is known as a multicast delegate 
        /// 
        /// In c# delegate are multicast which means that they point to more than one fucntion at a time . They are derived from 
        /// System.MulticastDelegate class 
        /// 
        /// we can use += and -= assignment operator to implment multi cast delegate 
        /// 
        /// </summary>
        /// 

        // Single Delegate 
        public static void Hello(string strMessage )
        {
            Console.WriteLine(strMessage);
        }


        public static void Addition(int num1 , int num2)
        {
            int result = num1 + num2;
            Console.WriteLine($"Addition is : {result} ");
        }

        // Multiple Delegates 
        public static void cube(int num)
        {
            var result = num * num * num;
            Console.WriteLine($"Cube of {num} : {result} ");
        }

        public static void Table(int num)
        {
            for( int i=1;i<=10; i++)
            {
                var result = i * num;
                Console.WriteLine($"Table of {num} * {i} :{result} ");
            }

        }

        // Multi Cast Delegates 
        public static void Addition1(int num1, int num2)
        {
            var result = num1 + num2;
            Console.WriteLine($"Addition of Two Number {num1 } and {num2} : {result} ");
        }
        public static void Substraction1(int num1, int num2)
        {
            var result = num1 - num2;
            Console.WriteLine($"Substraction  of Two Number {num1 } and {num2} : {result} ");
        }
        public static void Multiplication1(int num1, int num2)
        {
            var result = num1 - num2;
            Console.WriteLine($"Multiplication  of Two Number {num1} and {num2} : {result} ");
        }
        public static void Divition1(int num1, int num2)
        {
            var result = num1 - num2;
            Console.WriteLine($"Division  of Two Number {num1} and {num2} : {result} ");
        }
    }

    
}
