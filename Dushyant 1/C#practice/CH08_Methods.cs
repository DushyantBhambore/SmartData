using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH08_Methods
    {

        /// <summary>
        /// THis is the non-static method/ instance method  that can call only by creating the instance of the class or creating the object of the classs  
        /// Non-Parameterize Construction 
        /// </summary>
        public void Show() // Declaration of the method 
        {
            Console.WriteLine("Welcome to new chapter Methods and Funciton ");
            Console.WriteLine("All the Best");
        }

        /// <summary>
        /// This is Declatation of static method 
        /// Static Method are call by simply using the class 
        /// </summary>
        public static void Show1()
        {
            Console.WriteLine("Welcome to new chapter Methods and Funciton ");
            Console.WriteLine("All the Best");
        }

        /// <summary>
        /// This is the parameterized fuction that return some value 
        /// Fuction with Arguments 
        /// passsing the argument we have three type 
        /// 1. Through Main method 
        /// 2. Through Default Value
        /// 3. Through named Argumnet   
        /// </summary>
        public static void Add(int a ,int b)
        {
            
            int c = a + b;
            Console.WriteLine("Addtion is ="+c);
        }

        /// <summary>
        /// The option value/ default value  is for if in paramenter the  name is not enter  then the default name or age should be return 
        /// </summary>
        /// <param name="name"></param>
        public static void DefaultValue(string name ="Unknow")
        {
            Console.WriteLine("Your name is ="+name);
        }

        /// <summary>
        /// In this mehtod we have learn the named arguments 
        /// at  the time of passing the argumnet from the mail mehtod ,if supppose we have suffle the arguments then there is complie time error oucr 
        /// we have to over come this error we can use the named argumnets 
        /// </summary>
        public static void Show_Name_Age(string name , int age )
        {
            Console.WriteLine("My name is = "+name);
            Console.WriteLine("My age is ="+age);
        }

        public static int Add1(int a , int b)
        {
            int result = a + b;
            return result;
        }
    }
}
