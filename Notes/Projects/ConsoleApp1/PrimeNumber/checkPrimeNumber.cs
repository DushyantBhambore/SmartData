using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.PrimeNumber
{
    internal class checkPrimeNumber
    {
        public static void Test()
        {
            Console.WriteLine("Enter a  Number =");
            var num = Convert.ToInt32(Console.ReadLine());

            bool isprime = true;

            for(int i=2;i<num;i++)
            {
                if(num%i==0)
                {
                    isprime = false;
                    break;
                }
            }

            if (isprime)
            {
                Console.WriteLine($"Number {num} is prime ");
            }
            else
            {
                Console.WriteLine($"Number {num} is not Prime");
            }
        }
    }
}
