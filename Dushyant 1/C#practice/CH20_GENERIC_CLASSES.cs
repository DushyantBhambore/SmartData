using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH20_GENERIC_CLASSES
    {
        ///<summary>
        ///
        /// Generic classes define functionalities that can be used for any data type are declared with a class declaration followed by a type parameter enclosed within angular brackets 
        /// 
        /// Generics allow you to define a class with placeholder for the type of its fields , methods , parametes, etc . Generrics replce these placeholder with some specific type at compiler time 
        /// </summary>
        /// 

    }

    class Example<T>
    {
        T b;

        public T MyProperty { get
            {
                return this.b;
            } set
            {
                this.b = value;
            } }

        //public Example(T b)
        //{
        //    this.b = b;
        //}
        //public T GetValue()
        //{
        //    return this.b;
        //}


    }
}
