using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH06_Loops
    {
        public static void While_Loop()
        {
            Console.Write("Enter a number =");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            while (i < n)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }

        public static void Do_While_Loop()
        {
            Console.Write("Enter a number =");
            int n = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < n);
        }

        public static void For_Loop()
        {
            Console.Write("Enter a number =");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static void Nested_For_Loop()
        {
            Console.Write("Enter a number =");
            int n = Convert.ToInt32(Console.ReadLine());

            for(int i=1;i<=n;i++)
            {
                for(int j=i;j<=n;j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void For_Each_Loop()
        {
            //  string [] cars = { "Volvo", "BMw", "Ford", "Audi", "Mazda" };
            int[] cars = { 1, 2, 3, 5, 67, 764 };
            foreach(var i in cars)
            {
                Console.WriteLine(i);
            }
            
        }
          
    }
}
