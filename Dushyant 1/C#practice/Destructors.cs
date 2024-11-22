using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Destructors
    {
        ///<summary>
        ///A destructor is a special method which has the same name as the class but starts with the character ~ before the class name and immediately de-allocates memory of objects that are no longer required 
        ///
        /// Features :-
        /// Destructors cannot be overloaded or inherited .
        /// Destructors cannot be explicitly invoked 
        /// Destructord cannot specify access modifiers and cannot take parameter 
        ///</summary>
        ///

        //public string name;
        //public int age;

        //public Destructors(string name , int age)
        //{ 
        //    this.name = name;
        //    this.age = age;
        //}

        //public string Getname()
        //{
        //    return  this.name;
        //}

        //public int Getage()
        //{
        //    return  this.age;
        //}

        public Destructors()
        {
            Console.WriteLine("This is a constructor invoked !!");
        }


        ~Destructors()
        {
            Console.WriteLine("Destructors has been inveked !!!");
        }
    }
}
