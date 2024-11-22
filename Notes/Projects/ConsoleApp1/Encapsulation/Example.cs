using Basics.AnonymousFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Encapsulation
{
    internal class Example
    {
        // Encapsulation using Property 

        // this is private field it can access only through this class 
        private string? Name;
        private int age;

        public string? MyProperty1 
        {
            get 
            { return Name; }
            set
            { Name = value; }
        }

        public int MyProperty2 { get { return age; } set { age = value; } }


        public int firstNumber;
        public int secondNumber;

        public int Add(int a,int b )
        {
            //var result = a + b;
            //Console.WriteLine($"Addition = { result}");
            return a + b;
        }

        public int Sub(int a,int b)
        {
            //int result = a - b;
            //Console.WriteLine($"Subtraction = {result}");
            return a - b;

        }
    }
}




