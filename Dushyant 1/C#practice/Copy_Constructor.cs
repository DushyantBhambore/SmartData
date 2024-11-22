using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Copy_Constructor
    {
        ///<summary>
        ///The constructor which create an object by copying variable from another objects is called a copy constructor . Thre Purpose of a copy constructor is  to initialze a new instance to the exisitng instce
        ///
        /// Copy Constructor is a parameterized constructor which contains a parameter of same class type . 
        /// The copy constructor in c# useful whenever to initialize a new instance to the vlaue of an exiting instance 
        /// 
        /// In Simple words we can say copy constructor is a constrictor which copies a data of one object into another object 
        ///</summary>
        ///
        string name;
        int age;

        public Copy_Constructor(string name, int age)
        {
            this .name = name;
            this .age = age;
        }
        // This is copy constructor 
        public Copy_Constructor(Copy_Constructor copy)
        {
            this.age = copy.age;
            this.name = copy.name;
        }

        public void getdata()
        {
            Console.WriteLine("name is ={0}",name);
            Console.WriteLine("Age is ={0}",age);
        }
    }
}
