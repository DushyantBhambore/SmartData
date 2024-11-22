using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.ConstructorExample
{
    public class Cars
    {
        // fields 
        private string _make;
        private string _model;

        // Constructor

        public Cars(string make ,string model)
        {
            _make = make;
            _model = model;
        }

        // Property Property 

        public string Make
        {
            set { _make = value; }
            get { return _make; }
        }

        public  void Drive()
        {
            Console.WriteLine($"Driving {_make} {_model}");
        }
    }
}
