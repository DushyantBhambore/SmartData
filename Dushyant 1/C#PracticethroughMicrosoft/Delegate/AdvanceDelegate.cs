using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.Delegate
{
    internal class AdvanceDelegate
    {
        ///The Advance Type Delegate 
        ///Actions : It has 0-16 input but its return void
        ///Predicate : It has return the bool value , Its required one parameter for check the condition
        ///Func : Mostly requied return parameter 
        ///
        
        public static void TaskDelegate()
        {
            Action action = delegate
            {
                Console.WriteLine("Action Called");
            };

            Predicate<int> predicate = delegate (int data)
            {
                Console.WriteLine("PRredicate Called");
                return data > 10;
            };

            Func<int, int> func = delegate (int data)
            {
                Console.WriteLine("Func Called");
                return data*data;
            };

            action();
            Console.WriteLine($"Value is {predicate(10)}");
            Console.WriteLine($"Value is {func(3)}");
        }

        // Using Lambda Fucntions 

        public static void TaskDelegate1()
        {
            Action action = () =>  Console.WriteLine("Action Delegate Invoked! \n Do some Task ");

            Predicate<int> predicate = (int data) => data > 10 ;


            Func<int, int> func = (int data) => data * data;

            action();
            Console.WriteLine($"Predicate Delegate Invoked \n Result {predicate(11)}");
            Console.WriteLine($"Func Delegate Invoked \n Result {func(10)}");

        }
    }
}
