using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH19_LAMBDA_EXPRESSION
    {
        public delegate void MyDelegate(int num);

        public delegate int  MyDelegate2(int num);

        public delegate int AddTwo(int num2,int num1);
        ///<summary>
        ///( => this is sign of Lamda expression)
        ///
        /// it is also works like an anonymous method 
        /// 
        /// The difference that in Lambda expression you dont need to specify the type of the value that you input thus making it more flexible to use 
        /// 
        /// It means lambda expression simplifier the anonymous function or  you can say that lambda expression is a shorthand for an anonymous function 
        ///  The Lambda expression is divide into two parts the ledt side is input and the right is the expression 
        ///  
        /// Two types lambda expression
        /// 
        /// 1. Statement Lambda : Consists of the input and a set of statement to be executed 
        /// 
        /// syntax :
        /// 
        /// input => (statement);
        /// 
        ///Npte : Does not return any value implicitly
        /// 
        /// 
        /// 2. Expression Lambda : Consists of the input and the expression 
        /// 
        /// Syntax : 
        /// input => expression;
        /// 
        /// Note : Return the eveluated value implicitly  
        /// </summary>

    }
}
