using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class Private_Constructor
    {
        ///<summary>
        ///When a construcotr is created wit a private specific it is not pissible for other classes to derive from this class .neither is it posssible to cretae an instance of this class. They are ussually used in classes that conatin static members only . Some Key points of a private constructor are 
        ///
        /// One use of privete constructor is when we have only static members 
        /// Once we provide a cinstrictor thats is either private or public or any , the compiler will not add the paramneter-less public constructor to the class 
        /// In the presence of parameterless private constructor your cannot .
        /// 
        /// We cannot inherit the class in which we have a private cosntructor 
        /// 
        ///we can have paramterize constructor 
        ///</summary>
        ///
       
        private Private_Constructor()
        {
            Console.WriteLine("This is a paramterized Constructor ");
        }


    }
}
