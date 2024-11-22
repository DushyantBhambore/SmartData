    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH12_Polymorphism
    {
        ///<summary>
        ///Polymorphism and Overriding Methods
        ///Polymorphism means "many forms", and it occurs when we have many classes that are related to each other by inheritance.
        ///
        /// Like we specified in the previous chapter; Inheritance lets us inherit fields and methods from another class. Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.
        /// 
        /// Why And When To Use "Inheritance" and "Polymorphism"?
        ///  It is useful for code reusability: reuse fields and methods of an existing class when you create a new class.
        /// 
        /// </summary>
        /// 


    }

    public class Animal
    {
        public  void AnimalSound()
        {
            Console.WriteLine("This is a Animal Sound ");
        }
    }

    public class Cat : Animal
    {
        public  void CatSound()
        {
            Console.WriteLine("We have override the cat sound over the animal sound");
        }
    }
    public class Dog : Animal
    {
        public  void DogSound()
        {
            Console.WriteLine("We have override the dog sound over the animal sound ");
        }
    }

    ///<summary>
    /// 
    /// C# provides an option to override the base class method, by adding the virtual keyword to the method inside the base class, and by using the override keyword for each derived class methods:
    /// </summary>

    public class Accounts
    {
        public virtual void Acocount ()
        {
            Console.WriteLine("The Account is seen by only its derived class");
        }
    }

    public class Memebers : Accounts
    {
        public override void Acocount () 
        {
            Console.WriteLine("Here is the  memebers accounts ");
        }
    }

    public class SpecialAccount : Accounts
    {
        public override void Acocount()
        {
            Console.WriteLine("Here is the Special Accounts ");
        }
    }
}
