using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.AbstactExample
{
    abstract class Cars
    {
        public abstract void Model();

        public void BMW()
        {
            Console.WriteLine("BMW 5 star series");
        }
    }

    class CarsColour  : Cars
    {
        public override void Model()
        {
            Console.WriteLine("Red Color")      ;
        }
    }
}
