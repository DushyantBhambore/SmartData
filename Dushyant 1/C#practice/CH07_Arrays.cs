using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07_Arrays
    {
        public static void Arrays_Declaration()
        {
            // Declaration of Arrays 
            int[] new_arr = new int[4];
            new_arr[0] = 1;
            new_arr[1] = 2;
            new_arr[2] = 3;
            Console.WriteLine(new_arr[0]);
            int[] myarr = { 1, 3, 4, 5, 6, 7, };
            Console.WriteLine(myarr[3]);
            string[] my_arrays = new string[4] { "abc", "Volvo", "BMW", "AUDI" };
            Console.WriteLine(my_arrays[2]);
        }

        public static void Array_Length()
        {
            string[] arr = new string[5] { "Volvo", "BMW", "MERCEDIZE", "AUDI", "PORSCH" };
            Console.WriteLine(arr.Length);
        }

        public static void LOOPIN_Array()
        {
            int[] arr = { 1, 24,34,23322,53254,35,11,1133,4343 };
            Console.WriteLine($"Length of Array ={arr.Length}");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine( "------------------------");
           // Sorting of array 
            Array.Sort(arr);
            foreach (var i in arr)
            {
                Console.Write(i+" ");
                
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            // System.Linq namespace are used 
            Console.WriteLine(arr.Max() + " ");
            Console.WriteLine(arr.Min() + " ");
            Console.WriteLine(arr.Sum() + " ");
        }

        public static void MAX_MIN_SUM()
        {
            int[] arr = { 1, 2, 4, 5 };

            Console.WriteLine(arr.Max()+" ");
            Console.WriteLine(arr.Min() + " ");
            Console.WriteLine(arr.Sum() + " ");

        }
    }
}
