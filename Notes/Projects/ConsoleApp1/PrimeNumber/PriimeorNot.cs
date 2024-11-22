using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.PrimeNumber
{
    internal class PriimeorNot
    {
        public void Isprime(int num )
        {
            bool checkprime = true;
           
            for(int i=2;i<num;i++)
            {
                if(num%i==0)
                {
                   
                    checkprime = false;
                    break;
                }
                
            }
            if (checkprime)
            {
                Console.WriteLine($"Number {num} is Prime Number");
            }
            else
            {
                Console.WriteLine($"Number {num} is not Prime Number");
            }
        }
    }
}
