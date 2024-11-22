using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07C_Queue
    {
        ///<summary>
        ///
        /// Queue meaning : a line or sequence of people or vehicle 
        /// 
        /// Queue uses the FIFO principle (First IN First Out )
        /// 
        /// Queue collection allow multiple null and duplicate values 
        /// 
        /// Use the Enqueue() method to add value and the Dequeue() Method to retrive the value from the Queue 
        /// 
        /// Properties and Methods of Queue
        /// 
        /// Count - Returns the total count of elements in the Queue 
        /// Enqueue - Adds an item into the queue 
        /// Dequeue - Removes and returns an item from the beganing of the queue
        /// Peek - Return first item from the queue 
        /// Contains - Checks whether an item is in the queue or not 
        /// </summary>
        /// 

        public static void TestQueue()
        {
            Queue myqueue = new Queue();
            myqueue.Enqueue(1);
            myqueue.Enqueue("Dushyant");
            myqueue.Enqueue("");
            myqueue.Enqueue(null);
            myqueue.Enqueue(true);
            myqueue.Enqueue('A');
            myqueue.Enqueue("BHamabore");
            myqueue.Enqueue(true);

            Console.WriteLine(myqueue.Count);
            Console.WriteLine(myqueue.Contains('A'));
            Console.WriteLine(myqueue.Peek());
            
            Console.WriteLine(myqueue.Count);

            foreach (var item in myqueue)
            {
                Console.WriteLine(item);
            }

            myqueue.Dequeue();

            Console.WriteLine(myqueue.Count);
            Console.WriteLine("-------------------");
            foreach (var item in myqueue)
            {
                Console.WriteLine(item);
            }

            myqueue.Clear();
        }
    }
}
