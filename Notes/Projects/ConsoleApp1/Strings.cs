using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Strings
    {
        public static void Test()
        {
            Console.WriteLine("Enter Your First Name =");
            // if we used the string data types insted of var there is generating a Warning
            // Like this "Converting null literal or possible null value to nuon nullable type"
            // solution : used var 
            var first_name = Console.ReadLine();
            Console.WriteLine("Enter Last Name = ");
            var last_name = Console.ReadLine();
            Console.WriteLine(first_name.ToUpper());
            Console.WriteLine(last_name.ToUpper());
            Console.WriteLine(first_name.ToLower());
            Console.WriteLine(last_name.ToLower());
            Console.WriteLine($"My Fist Name {first_name} and  Last Name {last_name}");
            Console.WriteLine($"Length Of My First Name {first_name.Length} and Length of Last Name {last_name.Length}");
            Console.WriteLine(first_name.Remove(2));
            Console.WriteLine(last_name.Remove(3));
            // If get inup from user and old value gates null the error should like
            // System.ArgumentException: 'The value cannot be an empty string. (Parameter 'oldValue')'
            // solutions : Simply add the variable name  in the old value instaed of string 
            first_name =  first_name.Replace(first_name,"                 Harvord          ");
            Console.WriteLine($"New First Name = {first_name}");
            last_name = last_name.Replace(last_name, "            Stark             ");
            Console.WriteLine($"New Last Name = {last_name}");

            first_name = first_name.TrimEnd();
            Console.WriteLine($"After End Trim used [{first_name}]");


           
            Console.WriteLine($"Searching string{first_name.Contains("My Name is Harvord")}");
            Console.WriteLine($"Searching string {last_name.Contains("stark")}");
            Console.WriteLine($"The Word is start with {first_name.StartsWith("My")}");
            Console.WriteLine($"The word is end with {first_name.EndsWith("Harvord")}");


            string message = "FirstProject";
            Console.WriteLine($@"https://learn.microsoft.com/en-us/training/modules/csharp-basic-formatting/4-exercise-string-interpolation {message}");

        }
    }
}
