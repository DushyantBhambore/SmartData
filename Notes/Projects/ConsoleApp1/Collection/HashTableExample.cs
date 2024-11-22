using System.Collections;

namespace Basics.Collection
{
    internal class HashTableExample
    {
        public static void Test()
        {

            // Uses Memeory Queue
         
            Hashtable cities  = new Hashtable();
            cities.Add(0, "Nagpur");
            cities.Add(1, "Mumbai");
            cities.Add(2, "Pune");
            cities.Add(3, "Bangeloru");
            cities.Add(4, "");
            cities.Add(5, 440032);

            

            Console.WriteLine(cities.Contains(0));
            Console.WriteLine(cities[2]);
            foreach(DictionaryEntry i in cities)
            {
                Console.WriteLine($"The Key {i.Key} and Value is {i.Value}");
            }

        }
    }
}
