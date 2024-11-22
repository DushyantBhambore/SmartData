using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07B_Stack
    {
        ///<summary>
        ///Stack means pile of objects 
        /// 
        /// Stack uses the LIFO Principle ( Last In First Out )
        /// 
        /// Stack allow null value and also duplicate values . it provides a Pudh() method to ass a value and Pop() or Peek() mehtod to retrive values
        /// 
        /// A stack is used to create a dynamic collection which grows according to the need of your program 
        /// The capacity of a stack is the number of elemet the stack can hold . As element are added to a Stack , the capacity is automatically increased as required through reallocation 
        /// 
        /// In a stack you can store elements of the same type or different types
        /// 
        /// The Stack class implements the IEnumerable , ICollection and ICloneable interface 
        /// 
        /// 
        /// Properties and Methods of stack 
        /// 
        /// Count - Returns the total count of element in stack .
        /// Push - Insert an item at the top of the stack 
        /// Peek - Return the top item from the stack 
        /// Pop - Remove and return item from the top of the stack 
        /// 
        /// Contains -  Check whether an ite, exits in the stack or not .
        /// 
        /// Clear - Remove all item from stack 
        /// </summary>
        /// 


        public static void TestStack()
        {
            Stack mystack = new Stack();
            mystack.Push(123);
            mystack.Push("Dushyant");
            mystack.Push("Salary");
            mystack.Push(234);
            mystack.Push(23.3233);
            mystack.Push("SmartData");

            Console.WriteLine(mystack.Contains("Dushyant"));
            Console.WriteLine(mystack.Count);
            var a = mystack.Peek();
            Console.WriteLine(a);
            foreach (object item in mystack)
            {
                Console.WriteLine(item);
            }

            mystack.Pop();
            
            Console.WriteLine("--------------");
            foreach (object item in mystack)
            {
                Console.WriteLine(item);
            }
            mystack.Clear();
            Console.WriteLine(mystack.Pop()); ;

        }
    }


}
