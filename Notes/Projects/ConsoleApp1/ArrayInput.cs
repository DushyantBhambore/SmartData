using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class ArrayInput
    {
        public void Test()
        {
            Console.WriteLine("Ente Size of Array =");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] number = new int[size];

            // User Input of Array
            for(int i=0;i<size;i++)
            {
                Console.WriteLine($"The Arrray input is {i+1}");
                number[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Print Array 

            int maxnumber = number[0];

            Console.WriteLine("The Numbers are =");
            for(int i=0;i<size;i++)
            {
                if (number[i] > maxnumber)
                {
                    maxnumber = number[i];
                    Console.WriteLine(maxnumber+" it is greatest number");

                }
            }

        }

    }
}
