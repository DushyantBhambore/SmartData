using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Collection
{
    internal class DictionaryEample
    {
        public static void TestExaple()
        {
            Dictionary<int, string> keys = new Dictionary<int, string>();
            keys.Add(0, "One");
            keys.Add(1, "Two");
            keys.Add(3, "Three");
            keys.Add(4, "Four");

            Console.WriteLine(keys[4]);
            Console.WriteLine("Print Dictonary ");
            foreach (var key in keys)       
            {
                Console.WriteLine($"Key is {key.Key} and Value is {key.Value}");
            }

        }
    }
}
