using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH18_Anonymous_Function
    {
        public delegate void MyDelegate(int num);

        public delegate int MyDelegate2(int num);
        ///<summary>
        /// we discussed that delegated are used to reference any mehtods that has the same signature as that of the delegates.
        /// 
        /// As the name suggests , an anonymous method is a method without a name just the body 
        /// 
        /// Anonymous method in c# can be defined using the delegate keyword.
        /// 
        /// Anonymous method can assigned to a variable of delegate type 
        /// 
        /// You need not specify the return type in an anonymous mehtod; it is inferred from the return statement inside the method body
        /// 
        /// we dont required to use access modifiers with anonymous function like public, private , etc
        /// 
        /// Lesser typing work beacuse we dont required to write access modifier, return type 
        /// 
        /// Anonymous function are suggested when code volume is less 
        /// 
        /// Limitation
        /// 
        /// it cannot jump statement like goto,break,or continue 
        /// 
        /// it cannot acess ref or out parameter of an outer mehtod 
        /// 
        /// POINTS TO REMEMBER 
        /// 
        /// 
        /// Anonymous mehtod can be defined using the delegate keyword 
        /// 
        /// Anonymous method must be assigned toa delegate 
        /// 
        /// Anonymous mehtod can access to a delegate 
        /// 
        /// Anonymous mehtod can accss outerr variable or function 
        /// 
        /// Anomymous mehtod can be passed as a parameter 
        /// 
        /// Anonymous Method can be used as event handler 
        /// </summary>
        /// 

        public static void MyFucntion(MyDelegate del , int a)
        {
            a += 10; // 15 
            del.Invoke(a); 
        }

    }
}
