using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assesment1.Question4
{
//    4. Create a function that takes list of numbers which applies filter of multiple of 3, order by number, and
//returns list of string having "The number " + number.Ex. for 10 the string will be "The number 10".
    internal class Questio4
    {
        public static void listFunction()
        {
            var mylist = ListOFFunction();

            // print the multiple of 3
            Console.WriteLine("Multiple of 3 is ");
            var test = mylist.Where(x => x % 3 == 0);
            foreach (var item in test)
            {
                Console.WriteLine($"The Number is {item}");
            }
            // print List using order by 
            Console.WriteLine("Print List Using Order BY ");
            var test2 = mylist.Order().ToList();

            test2.ForEach(x => Console.WriteLine($"The Number is {x}"));
        }

        // create a List Function return List
        public static List<int> ListOFFunction()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return list;
        }

    }
}
