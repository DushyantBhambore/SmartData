using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class MultiDimentional_Array
    {
        //Decleration       
       
        public static void Rectangular_Array()
        {
            // rectangular array declaration 
            // int[,] myarr = new int[3,2];
            int[,] myarr = new int[3, 2]
            {
                {1,31},
                {2,31},
                {3,31},
            };

            // Accessig by foeach loop 
            Console.WriteLine("Accessig by foreach loop");
            foreach (var i in myarr)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Accessig by for loop");

            // In multidimentional array acces the array element by for loop we have to use Getlenght(0) intesd of length
            for(int i=0;i<myarr.GetLength(0);i++ )
            {
                for(int j=0;j<myarr.GetLength(1);j++ )
                {
                    Console.Write(myarr[i,j]+" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine( " Shoow the how many dimension of array");
            Console.WriteLine(myarr.Rank);
        }

        public static void Jagged_Array()
        {
            // Declaration int[][] arr = new int[][];

            int[][] arr = new int[3][];
            arr[0] = new[] {1,2,3,4,5,6,7,8};
            arr[1] = new[] { 11, 22, 33, 44, 55, 55 };
            arr[2] = new[] { 111, 222, 444, 333 };
            //Console.WriteLine(arr[2][3]);
            Console.WriteLine("Accessig by foreach loop");
                
            foreach (int[] i in arr)
            {
              foreach(var item in i)
                {
                    Console.Write(item+" ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Accessig by for loop");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine(" Shoow the how many dimension of array");
            Console.WriteLine(arr.Rank);

        }
    }
}
