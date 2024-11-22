using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Collection
{
    internal class ArrayListExample
    {

        public static void  Example()
        {
            var arraylist = new ArrayList();
            arraylist.Add("Mumbai");
            arraylist.Add(23);
            arraylist.Add("Pune");
            arraylist.Add(43);

            Console.WriteLine("Array List is :");
            foreach (var i in arraylist)
            {
                Console.WriteLine(i);
            }

        }
    }
}
