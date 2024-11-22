using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Generics
{
    // T is for parameter 
    internal class GenericExample<T>
    {
        public T? Key { get; set; }
        public T Value { get; set; }
    }

    // Using Fields  and  functions
    public class  GenericExample2<T>
    {
        private T[] _data = new T[10];
        
        public void AddorUpdate(int index , T value)
        {
            if(index>=0 && index<10)
            {
                _data[index] = value;
            }

        }
        public T GetData(int index)
        {
            if(index>=0 && index<10)
            {
                return _data[index];
            }
            else
            {
                return default(T);
            }
        }
    }

    // Using Method
    public class Prints<T>
    {
        public void Print(T message)
        {
            Console.WriteLine($"Message is {message}");
        }
    }
}
