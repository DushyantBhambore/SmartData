    using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH03_Strings
    {
        public static void StringLength()
        {
            string text = "anfnknslkfnlsdf";
            Console.WriteLine(text.Length);

        }
        public static void StringConcatenation()
        {
            string firstname = "Jhone";
            string Lastname = "Doe";
            string name = firstname +" "+ Lastname;
            Console.WriteLine(name);
        }

        public static void StrigInterpolation()
        {
            string firstname = "Jhone";
            string lastname = "Doe";
            string name = $"My full name is : {firstname} {lastname}";// PLACEHOLDER 
            Console.WriteLine(name);
        }
        public static void AccessString()
        {
            string name = "HelloWorld";
            Console.WriteLine(name[2]);
            Console.WriteLine(name[0]);
            Console.WriteLine(name[1]);
            Console.WriteLine(name[4]);
        }

        public static void SubString()
        {
            /*            string name = "Jhon Doe";
                        // Location of string you want to break 
                        int  charpos = name.IndexOf("D");
                        //get the new name 
                        string newname = name.Substring(charpos);
                        Console.WriteLine(newname);*/

            string name = "Dushyant Bhambore";

            // Location of string you eant to break 
            int locbreak = name.IndexOf("B");
            // New String followed 
            string newname = name.Substring(locbreak);
            Console.WriteLine(newname);
        }
    }
}
