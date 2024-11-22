using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    /// <summary>
    ///  
    /// Enum is a set of Constants 
    /// 
    /// An enum is a special "class" that represent a group of constant (unchangeable/read-only variable)
    /// 
    /// Enum is short for "enumerations", Which means "specifically listed "
    /// 
    /// TO create an enum , use the enum keyword (instead of class or interface ), and separate the enum items with a comma
    /// 
    /// an enum ( or enumeration type ) is used to adding constant names to a group of numeric integer values
    /// 
    /// It makes constant values more readable , for example WeekDays.Monday is more readable then number when referring to the day in a week 
    /// 
    /// An enum is defined using the enum keyword, directly inside a namespace , class , or structure . All the constant names can  be declared inside the curly breackets and seprated by comma4
    /// 
    /// The dafault underlying type of an enum is int 
    ///
    /// The default value for first element is ZERO and gets incremented by 1 
    /// 
    /// Enum are value types 
    /// 
    /// Enum are more readable and maintainable 
    /// 
    /// Enum converted into abstract class behind the scenes .
    ///
    /// *** C# Enum Value 
    /// 
    /// If values are not assogn to enum members, then the compiler will assign integer values to each member starting with zero by default 
    /// 
    /// You can assign the different values to the enum members 
    /// 
    /// A change in the default values of an enum members will automatically assign incremental values to the other members sequentially .
    /// 
    /// *** ENUM CONVERSION 
    /// 
    /// Explicit casting is required to convert from an enum type to its underlying intgral type 
    /// 
    /// **** Why And When to Use enums 
    /// 
    /// Use enums when you have values that you known arent going to change, like month days,days ,colors etc 
    /// 
    /// In c# switch can act upon enum values 
    /// 
    /// </summary>
    public class CH25_Enum_
    {

        public static void Test()
        {
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("My name is Dushyant");

            //Console.WriteLine("Enter Your name =");
            //string? name = Console.ReadLine();

            //Console.WriteLine("Enter the day accoding to the number (Sunday =0,Monday=1,Tuesday=2,Wednessday=3)etc =");
            //int number = Convert.ToInt32(Console.ReadLine());

            //Days myday = (Days)number;
            //Console.WriteLine($"My name is ={name} and My enterd number ={number} also the day what i got = {myday}");

            // print the all members inside the enum class  
            //string[] members = (string[])Enum.GetNames(typeof(Days));
            //Console.WriteLine("Members which you gets =");
            //foreach (var item in members)
            //{
            //    Console.WriteLine(item);
            //}

            //// print the values of all memeber inside the enum class 
            //int[] values = (int[]) Enum.GetValues(typeof(Days));
            //Console.WriteLine("The Values I got =");
            //foreach (var item in values )
            //{
            //    Console.WriteLine(item);
            //}
            // switch can act upon enum values 

            //Days days = Days.Saturday;
            //switch (days)
            //{
            //    case Days.Sunday:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is Saturday");
            //        break;
            //    case Days.Monday:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is Monday");
            //        break;
            //    case Days.Tuseday:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is TuseDay");
            //    break;
            //    case Days.Wednessday:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is Wednessday");
            //        break;
            //    case Days.ThursDay:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is ThursDay");
            //        break;
            //    case Days.FriDay:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is FriDay");
            //        break;
            //    case Days.Saturday:
            //        Console.ForegroundColor = ConsoleColor.Yellow;
            //        Console.BackgroundColor = ConsoleColor.Green;
            //        Console.WriteLine("This is Saturday");
            //        break;

            //    default:
            //        Console.WriteLine("Invalid day ");
            //        break;
            //}


            int days = (int)Days.FriDay;
               switch (days)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 2");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 3");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 4");
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 5");
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 6");
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Number is 7");
                    break;

                default:
                    Console.WriteLine("Invalid day ");
                    break;
            }

        }

    }

    enum Days
    {
   // enum members : sunday ,monday ,etc in this code 
        Sunday =1,//0 enum value 
        Monday ,//1
        Tuseday,//2
        Wednessday,//3
        ThursDay,//4
        FriDay,//5
        Saturday//6
    }
}
