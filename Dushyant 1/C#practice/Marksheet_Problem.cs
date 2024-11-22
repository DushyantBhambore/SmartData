using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Marksheet_Problem
    {
        public static void Marks_Sheet()
        {
            Console.Write("Enter your name=");
            string? name = Console.ReadLine();
            Console.Write("Enter your Class = ");
            string? c = Console.ReadLine();
            Console.Write("Enter your subjets Marks ");
            Console.WriteLine("Enter English Marks =");
            int e = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Marathi Marks =");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Physics Marks =");
            int p = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Chemistry Marks =");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Boilogy Marks =");
            int b = Convert.ToInt32(Console.ReadLine());

            int total = (e + m + b + p + ch);
            int per = (total *100)/ 500;
            Console.WriteLine($"Your Total Marks ={total}");
            Console.WriteLine($"Your Percentage = {per}");
            if (per>75)
            {
                Console.WriteLine("Congratulation You achived Distinction ");
            }
            else if(per>50 && per<75)
            {
                Console.WriteLine("Cogratlation You Achived Merit List ");
            }
            else if(per>35 && per<50)
            {
                Console.WriteLine("Congratulation You are Pass");
            }
            else
            {
                Console.WriteLine("Sorry You are Fail");
            }
        }
    }
}
