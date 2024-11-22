using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.AnonymousFunction
{


    public class Example
    {
        public delegate void Valuedelegat(int val);

        public delegate void Mydelegate(int a);
        public static void Number(Mydelegate d, int a)
        {
            a = 10;
            d.Invoke(a);

        }

        internal static void Test()
        {
            throw new NotImplementedException();
        }
    }
}
