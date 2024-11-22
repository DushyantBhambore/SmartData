using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.AccesModifier
{
    public class BadClass
    {
        

        public string creadictCardNumber;

        private string? AdharNumber;

        public string ADDHARNumber 
        { 
            get
            {
                return AdharNumber;
            }set
            {
                AdharNumber = value;
            }
        }
    }
}
