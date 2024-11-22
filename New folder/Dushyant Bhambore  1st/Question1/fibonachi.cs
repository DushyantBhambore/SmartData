using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1.Question1
{
    
//1. Create function that takes item count as input and
//returns the list of first terms of Fibonacci series
//base on provided input value.
    public class fibonachi
    {
        // print a fobonacci series 
        public static List<int> GetFibonacciSeries(int count)
        {
            // take the input from user and check its zero or not 
            if(count <= 0)
            {
                return new List<int>();
            }
            // Initialize the List 
            List<int> fibonacci = new List<int>();

            // i have initialze the firstnumber as 0 and secondnumber as 1 with simple condition
            int firstnNmber = 0, secondNumber = 1;

            if (count > 0)
            {
                fibonacci.Add(firstnNmber);
            }
            if (count > 1)
            {
                fibonacci.Add(secondNumber);
            }

            // created a loop less than equal count

            for(int i=2;i<=count;i++)
            {
                var newnumber = firstnNmber + secondNumber;
                fibonacci.Add(newnumber);
                firstnNmber = secondNumber; // here i have swap the firstnumber and secondnumbe 
                secondNumber =newnumber;
            }
            // return list 
            return fibonacci;
        }
    }
}
