using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Basics.Assignment
{
    internal class AssignmentExample
    {
        public static void Test()
        {
            int n = 1234;
            int rem;
            int reverse = 0;
            while (n > 0)// (i<n) //wrong 
            {
                rem = n % 10;
                n = n / 10;
                reverse = reverse*10 + rem;
                
            }
            Console.WriteLine(reverse);         

        }
    }
}
