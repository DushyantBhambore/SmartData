using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft
{
    public class CH01_Variable
    {
        public static void Test()
        {
            string afriend = "My Name is Dushyant";
            Console.WriteLine("Hello "+afriend);

            string songlyrics = "You say goodbye, and I say hello";
            Console.WriteLine(songlyrics);
            Console.WriteLine(songlyrics.Contains("goodbye"));
         string a =songlyrics.Replace("goodbye","goodbyebeautiful");
            Console.WriteLine(a) ;


        }

        public static void Test1()
        {
            var names = new List<string> {"<names>",  "Ana", "Fellipe" };


            names.Add("Milis ");
            names.Add("Mines");
            names.Remove("Ana");

            names.Sort();
            foreach (var item in names)
            {
                Console.WriteLine($"Hello {item.ToUpper()}");
            }
            Console.WriteLine(names[1]);

            var index = names.IndexOf("Ana");
            Console.WriteLine(index) ;

            if (index == -1)
            {
                Console.WriteLine($"When an item is not found , IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }
        }

        public static void Test2()
        {
            var fibonacchiNumbers = new List<int> { 1,1};


            while(fibonacchiNumbers.Count<20)
            {
                var previous1 = fibonacchiNumbers[fibonacchiNumbers.Count - 1];
                var previous2 = fibonacchiNumbers[fibonacchiNumbers.Count - 2];

                fibonacchiNumbers.Add(previous1 + previous2);

            }
            Console.WriteLine("Count = "+fibonacchiNumbers.Count);

            foreach (var item in fibonacchiNumbers)
            {
                Console.WriteLine(item);
            }

        }
    }
}
