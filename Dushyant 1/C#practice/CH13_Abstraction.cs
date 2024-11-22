using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH13_Abstraction
    {
        /// <summary>
        /// 
        /// Data abstraction is the process of hiding certain details and showing only essential information to the user.
        /// The abstract keyword is used for classes and methods:
        /// 
        /// Abstract class: is a restricted class that cannot be used to create objects (to access it, it must be inherited from another class).
        /// 
        /// Abstract method: can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from)
        /// 
        /// Why And When To Use Abstract Classes and Methods?
        /// To achieve security - hide certain details and only show the important details of an object.
        /// Note: Abstraction can also be achieved with Interfaces, which you will learn more about in the next chapter.
        /// </summary>
    }

    // Abstract class
      abstract class AbstractCLass
    {
        // Abstract method (does not have a body)
        //  public abstract int  Add(int a , int b);
        public abstract void Cars();

        public void mercedize ()
        {
            Console.WriteLine("This is Mercedice Car ");
        }
       
    }
        
      class AbstractClassImplementation : AbstractCLass
    {
        //public override int Add(int a , int b)
        //{
        //    return a + b; ;
        //}
        public override void Cars()
        {
            Console.WriteLine("This is Mercedice G-Wagon Model");
        }
    }
}
