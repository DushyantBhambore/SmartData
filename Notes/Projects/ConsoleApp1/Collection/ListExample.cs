using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Collection
{
    internal class ListExample
    {
        public static void City()
        {
            List<string> cities = new List<string>();

            cities.Add("Akola");
            cities.Add("Nagpur");
            cities.Add("Mumbai");
            cities.Add("Pune");

            Console.WriteLine("The City is at Index "+cities.IndexOf("Nagpur"));
            foreach(var i in cities)
            {
                Console.WriteLine(i);
            }
        }
    }
}
