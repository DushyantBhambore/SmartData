using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Static_Class
    {
        ///<summary>
        ///
        ///  Static Classes that cannot be istantiated or inherited are known as classes and the static keyword is used before the class name that consists of static data members and static methods 
        /// 
        /// it is not possible to create an instance of a static class using new keyword . Tha main feature of static classes are as follow:
        ///     They can only maintain staitc members 
        ///     They cannot be instaintiated or inherited and cannot contain instance constructor. Howeever the developer can create static constructor to initialize the static members 
        ///</summary
        ///
        public static int ProductId;
        public static string? ProductName;
        public static int Productprice;

        static Static_Class()
        {
            ProductId = 11;
            ProductName = "Watch";
            Productprice = 10000;
        }

        public static void get_productDetails()
        {
            Console.WriteLine($"Product Id ={ProductId}");
            Console.WriteLine($"Product Name ={ProductName}");
            Console.WriteLine($"Product Price ={Productprice}");

        }
        
        public static void get_productPrice() 
        {
            int data_amount = Productprice / 10;
            Console.WriteLine($"The Discount You Get ={data_amount}");
            Console.WriteLine($"The Total Price Amount After Discount is ={(Productprice-data_amount)}");
        }

    }
}
