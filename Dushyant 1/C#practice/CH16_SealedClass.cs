using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    class CH16_SealedClass
    {
        ///<summary>
        /// A Sealed is a class that prevent inheritance 
        /// 
        /// features 
        /// 
        /// A sealed class can be declared by preceding the class keyword  with the sealed keyword 
        /// The sealed keyword prevent a class from being inherited by any other class 
        /// The Sealed Class cannot ba same as it cannot be unherited by any other class . If a class tries to derive a seald class the c# compiler generates an error 
        /// 
        /// 
        /// Purpoese of Sealed Class :
        /// 
        /// Consider a class named SystemInformation that consists of critical methods taht affect the working of the operating system 
        /// 
        /// You might not want any third party to inherit the class Systeminformation and  override its methods , thus causing security and copyright issues 
        /// 
        /// Here you can delcare thr Systeminformation class as sealed to prevent any change in its variable methods 
        /// 
        /// 
        ///  *****----*****--
        ///  

        /// </summary>
    }

    //sealed  class BaseClass
    //  {
    //      public  void Show1()
    //      {
    //          Console.WriteLine("Methods of Base Class ");
    //      }
    //  }

    //class DerivedClass : BaseClass
    //{
    //    public void Show2()
    //    {
    //        Console.WriteLine("Mehthods of Derived Class ");
    //    }
    //}

    ///<summary>
    ///        /// SEALED METHODS      
    /// when the drived class overrides a base class method variable, property or event, then the new method variable, property , event can declared as sealed 
    /// 
    /// Sealing the new method prevent the method from further overriding
    /// 
    /// An Overridden mehthod can be sealed by proveding the override keyword with the sealed keyword 
    /// 
    /// 
    /// Steps to remember for sealed methods 
    /// 
    /// sealedd method is always an overriden method of child class 
    /// we
    /// 
    /// cannot again override the sealed method 
    /// 
    /// sealed method is only avaible with method overriding 
    /// 
    /// Sealed keyword is not avaible with the method hiding 
    /// Sealed is ued together with overrde method .
    /// 
    /// We cannot make normal methods as sealed 
    /// 
    /// </summary>
    /// 

    //class A
    //{
    //    public virtual void Print()
    //    {
    //        Console.WriteLine("This is a method of class A ");
    //    }
    //}

    //class B :A
    //{
    //    public sealed override void Print()
    //    {
    //        Console.WriteLine("This is a method of class B ");
    //    }
    //}

    //class C : B
    //{
    //    public override void Print() // error occur beacuse in above class B Method i have used the sealed keyword thats why we have cannot inherted the same method from the B class 
    //    {
    //        Console.WriteLine("This is a method of class C ");
    //    }
    //}
}
