using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assesment1
{
    //Create a function that takes list of numbers and returns list numbers with square of each number using Func.
    public static class Question3
    {
        public static void SquareExample( )
        {
            // use func for square number 
            // perform operation
            Func<int, int> func = number => number * number;
            
            List<int> list = new List<int> { 1,2,3,4,5};
            // store the list 
            List<int> squarenumber = list.Select(func).ToList();
            // print list 
            squarenumber.ForEach(a => Console.WriteLine(a));
            
        }
           

    }
}
