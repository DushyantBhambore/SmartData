using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.Encapsulation
{
    internal class Examp_e
    {
        private string name;
        private int age;


        public string Name 
        {
            get 
            {
                return name;
            }

            set {
                name=value;
            }
        }
    }
}
