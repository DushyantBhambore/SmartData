using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Basics.Abstraction.AbstrctionUsingInteface;

namespace Basics.Abstraction
{
    internal interface AbstrctionUsingInteface
    {
        public interface IAbstratInterfae{

            public string Name { get; set; }

            public int Add(int a, int b);

            public void MyName(string name);
        }


    }
    public class AbtractExample : AbstrctionUsingInteface
    {
        private string Name;
        public string MyProperty
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public void MyName(string message)
        {
            Console.WriteLine($"My Name is {message}");
        }
    }


}
