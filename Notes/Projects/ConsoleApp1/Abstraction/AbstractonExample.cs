using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Abstraction
{
     public abstract class AbstractonExample
    {
        public abstract string? sound { get; }

        public abstract void Walking();
        
        public abstract int Add(int a, int b);

    }

    public class AbsactioImplementation : AbstractonExample
    {
        public override string? sound => "Meow";
        public override void Walking()
        {
            Console.WriteLine("Cat is Walking...");
        }
        public override int Add(int a, int b)
        {
            return a + b;
        }
    }

    public class Dog : AbstractonExample
    {
        public override string? sound => "Woof";

        public override void Walking()
        {
            Console.WriteLine("Dog is Running .....");
        }
        public override int Add(int a, int b)
        {
            return (a - b);
        }
    }

}
