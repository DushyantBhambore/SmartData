using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH09_Constructor
    {
        // Constructor it is instance of an object 
        // Constructor has non-static method 
        // Constructor used to reduce the size of program/code 
        // Constructor are have diffrent types such as 
        // 1 . parameterize constructor / constructor oveloading 
        // 2. Default Constructor 
        // 3. Copy Constructor 
        // 4. Private Constructor 

        // Constructor Overloading 
        public CH09_Constructor()
        {
            Console.WriteLine("This is the First Cosntructor ");
        }
        public CH09_Constructor(int a, int b)
        {
            Console.WriteLine("This is the second Cosntructor ={0} ", (a + b));
        }
        public CH09_Constructor(string a, string b)
        {
            Console.WriteLine("This is the third Cosntructor ={0} ", (a + b));
        }


        ///<summary>
        ///Static Constructor is used to initialize static variable of the class and to perform a particular action only once
        ///static constructor is called only once no matter how many object you create 
        ///Static Constructor is called before instace (default or parameterized) constructor 
        ///A static constructor does not take any parameter  
        /// Only one static constructor can be created in the class 
        /// it is called automatocally before the first instace of the class 
        ///</summary>
        ///

        //public static string person_name;
        //public static int person_age;

        // static  CH09_Constructor()
        //{
        //    person_name = "ABC";
        //    person_age = 1;
        //    Console.WriteLine("This is the static constructor Invoked !!");
        //}
        //public  CH09_Constructor()
        //{
        //    Console.WriteLine("Default Constructor is Invokedd !! ");
        //}
        //public static void GetDetails()
        //{
        //    Console.WriteLine("Person Name = {0}",person_name);
        //    Console.WriteLine("Person Age ={0}");
        //}

        
        
    }
}
