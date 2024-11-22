using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLecture._09_09_24.Practice
{
    internal class Practice2
    {
        
        public static void Test()
        {
            MyFunction1();
            //MyFunction();
        }

        // Delegate Tyeps/ Advance Delegate 
        public static void MyFunction1()
        {
            Action<int> action = delegate (int data)
            {
                Console.WriteLine("Data Value is "+data);
            };

            Action<string> action1 = (value) => Console.WriteLine("Value is " + value);

            Predicate<int> predicate = delegate (int number)
            {
                return number == 1;
            };

            Predicate<int> predicate1 = (data)=>  data > 10;  

            Func<int, int, int> func = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine("Func is Invoked");
            Console.WriteLine("Addition is "+func(5,5));

            Func<int, int, int> func1 = (int data, int data1) => (data*data1);
            
            Console.WriteLine("Multiplication is "+func1(10,10));

            Console.WriteLine("Actioon is Invoked");
            action(100);
            action1("Hello");
            Console.WriteLine("Predicate is Invoked "+"\n The Condition is "+predicate(2) );
            Console.WriteLine("Predicate value check "+predicate1(11));

        }

        public static void MyFunction()
        {
            //Add(10, 20);
            //Add(12.1, 23.23);
            //Add("Abc ", "xyz");
            //Add(239L, 43842L);
            //Add<decimal>(5.2M,5.2M);
        }
        // Type Interface 

        public static T Add<T>(T number1, T number2)
        {

            dynamic a = number1;
            dynamic b = number2;
            return a + b;
            //return data1 * data2;
            //Console.WriteLine("My ID is "+ (data2*data1));
        }
        public static void Add(int a,int b)
        {
            Console.WriteLine("Int is :"+(a+b));
        }

        public static void Add(string a, string b)
        {
            Console.WriteLine("String Concatination  is :" + (a + b));
        }
        public static void Add(double a, double b)
        {
            Console.WriteLine("Double is :" + (a * b));
        }
        public static void Add(long a, long b)
        {
            Console.WriteLine("Long is :" + (a + b));
        }

    }
}
