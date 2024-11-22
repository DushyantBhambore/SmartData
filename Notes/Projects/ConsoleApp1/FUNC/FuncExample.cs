using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.FUNC
{
    internal class FuncExample
    {
        static int Sum(int x , int y)
        {
            return x + y;
        }
        static void Test()
        {
            Func<int, int, int> add = Sum;
            int result = add(10, 20);

            Console.WriteLine(result);
        }
    }
}
