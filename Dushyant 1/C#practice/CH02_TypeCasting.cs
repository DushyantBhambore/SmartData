using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH02_TypeCasting
    {
        public static void Casting()
        {
            //convert a number in string format i.e. "45" to integer

            int i = int.Parse("45"); //     a number in a string in a correct formate 
            Console.WriteLine(i);

            long l = long.Parse("43553453");
            Console.WriteLine(l);

            float f = float.Parse("33.233");
            Console.WriteLine(f);

            double d = double.Parse("34534.3434234");
            Console.WriteLine(d);

            bool b = bool.Parse("True");
            Console.WriteLine(b);
        }

        public static void TryParse()
        {
            int i;
            bool issuccess = int.TryParse("4a5", out i);
            Console.WriteLine("Response :"+issuccess+ " and value is "+i);

            float f;
            issuccess = float.TryParse("43.22", out f);
            Console.WriteLine("Response :" + issuccess + " and value is " + f);

            long l;
            issuccess = long.TryParse("345.3463", out l);
            Console.WriteLine("Response :" + issuccess + " and value is " +l);

            char s;
            issuccess = char.TryParse("hello", out s);
            Console.WriteLine("Response :"+issuccess+" and value is "+s);

        }
        public static void TypeConvert()
        {
            float f = 34.23f;
            int i = Convert.ToInt32(f);
            Console.WriteLine(i) ;

            bool b = Convert.ToBoolean("False");
            Console.WriteLine(b) ;

        }
    }
}
