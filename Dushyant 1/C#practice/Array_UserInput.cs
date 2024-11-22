using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Array_UserInput
    {
        public static void User_Input()
        {
            Console.WriteLine("Enter How many number Do you want to enter in the array =");
            int num = Convert.ToInt32(Console.ReadLine());
            string[] mynames = new string[num];

            for(int i=0;i<num; i++)
            {
                Console.WriteLine("Enter number at location ="+i);
                string? data = Console.ReadLine();
                mynames[i] = data;
            }

            Console.WriteLine("----- Your Data ----------");
            foreach(string name in mynames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
