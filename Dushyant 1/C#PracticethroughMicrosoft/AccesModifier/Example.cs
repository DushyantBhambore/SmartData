using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.AccesModifier
{
    public class Example
    {
        private void PrivateMethod()
        {
            Console.WriteLine("This is Private Class");
        }

        public void PublicMethod()
        {
            Console.WriteLine("This is Public Class");
            PrivateMethod();
        }
        protected void ProtectedMethod()
        {
            Console.WriteLine("This is Protected Class ");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("This is Internal Class ");
        }
    }

    public class Child1 : Example
    {
        public  void ChildClass()
        {
            Child1 cd = new Child1();
            // cd.PrivateMethod(); // Private Method is not accessible its protection level
            // Private Method  is not acces the its outside the function 

            cd.ProtectedMethod();
            cd.PublicMethod();
            cd.InternalMethod();
        }
    }
}
    