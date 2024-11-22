using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.Delegate
{
    public delegate void Mydelegate(int a, int b);

    internal class DelegateExample
    {
        // delegates its a pointer to a function 
        // Delegates is a delegate , Which is used function address to another function 
        // it is a call back function 
        // Delegate can be denote ouitside the class           





        public  void Addition(int a , int b)
        {
            int c = a + b;
            Console.WriteLine(c);
        }
    }
}
