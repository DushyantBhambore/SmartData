using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.TypeInfeerence
{
    internal class TypeInferenceImpotrantTopic
    {

        public static  void Test()
        {
            DosomeTask();
        }

        public static void DosomeTask()
        {
            Add(10, 20);
            Add("abc", "xyz");
            Add(123.23, 132.232);
            ExpertMethod<double>(3);
            
        }

        public static void ExpertMethod<T>(T data)
        {
            Console.WriteLine("The data is "+(data));
        }

        public static void Add(int a , int b)
        {
            Console.WriteLine("Addition is "+(a+b));
        }
        public static void Add(string a ,string b)
        {
            Console.WriteLine("Output is" + (a) + (b));
        }
        public static void Add(double a ,double b)
        {
            Console.WriteLine($"Addition is {a - b} ");
        }
    }

}
