using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH24b_Dependency_Injection
    {
    }
    // Dependency Injection through Methods
    /// <summary>
    /// Method Injection is injecting dependent class object through a class method 
    /// 
    /// what is mean by this ?
    /// 
    /// In the given example , Account class has dependency on SavingAccount and CurrentAccount classes 
    /// 
    /// So the method injection means, injecting SavingAccount & CurrentAccount class object directly into the Account class method using interface 
    /// </summary>

    public interface IAccount2
    {
        void PrintDetails2();
    }

    class SavingAccount2 : IAccount2
    {
        public void PrintDetails2()
        {
            Console.WriteLine("Deatils of Current Account");
        }
    }
    class CurrentAccount2 : IAccount2
    {
        public void PrintDetails2()
        {
            Console.WriteLine("Deatils of Saving Account");

        }
    }

    class Account2
    {
        public void PrintAccount(IAccount2 account) // parameterized method 
        {
            account.PrintDetails2();
        }
    }
}
