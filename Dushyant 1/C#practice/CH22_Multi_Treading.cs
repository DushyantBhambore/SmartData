using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH22_Multi_Treading
    {
        ///<summary>
        ///
        /// What is Thread :
        /// 
        /// Threads are lightweight processes 
        /// 
        /// A thread is defined as the execution path of a program 
        /// 
        /// Each thread defines a unique flow of control 
        /// 
        /// If your application involves compliated and time consumning operations, then it is often heplful to set different execution path or threads with each thread performing a particular job 
        /// 
        ///*****  Multi Threads :
        ///Multitreading is feature provided by the operating system that enables your application to have more than one execution path at the same time 
        ///
        /// Technically multithreading programming requires a multitasking operating sysstem 
        /// 
        /// Every application is executed in a process by operating system 
        /// 
        /// Proces use Thread to execute application code 
        /// 
        /// Every application has a single thread ny default to execute a program and that single thread is known as MAIN THRED
        /// 
        /// The threads created using the thread class are called the child threads of the main thread
        /// 
        /// You can access a thread using the CurrentThread property of the Thread class
        /// 
        /// Every application follows single threaded model 
        ///  
        /// Threads are executed by the operating system using time-sharing.
        /// 
        /// Threads are executed simultaneosly 
        /// 
        /// Threads executed and time sharig  is manage by operating system 
        /// 
        /// 
        /// Properties :
        /// 
        /// CurrentThread() : Gives a reference to the currently executing thread 
        /// 
        /// Thread.Sleep() : cause the currently executing thread to pause temporarily for the specified amount of time 
        /// </summary>
        /// 


        public static void Tets()
        {
            Thread t = Thread.CurrentThread;

            t.Name = "Hello Threads";
            Console.WriteLine("Main Threads is excuted "+Thread.CurrentThread.Name); 

        }

        public static void Function1()
        {
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine("Function 1 is executed ="+i);
                if(i==10)
                {
                    Console.WriteLine("Function 1 is going to sleep for 8 sec!!!!");
                    Thread.Sleep(8000);
                }
            }
        }

        public static void Function3()
        {
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine("Function 3 is executed =" + i);
                if(i==10)
                {
                    Console.WriteLine("Function 3 is goging to sleep for 10 sec  ----");
                    Thread.Sleep(10000);
                }
            }
        }
        public static void Function2()
        {
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine("Function 2 is executed =" + i);
            }
        }


    }
}
