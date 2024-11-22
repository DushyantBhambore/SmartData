using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft
{
    abstract class AbtractClass
    {
        public abstract void AnimalSound();

        public void Sleep()
        {
            Console.WriteLine("zzz");
        }
    }

    class Dog : AbtractClass
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Bow  Bow ");
        }
    }
}
