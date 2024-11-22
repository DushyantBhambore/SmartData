using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH24a_Dependency_Injection
    {
    }
    // Dependency Inhection Through Property Injection 


    public interface IAccount1 // if suppose i have used the Account interface here it has showing error that error is the Account interface is already present in the namespaces same for other classes also 
    {
        void PrintMessage();
    }

    public class CurrentAccount1 : IAccount1
    {
        public void PrintMessage()
        {
            Console.WriteLine("Deatils of Current Account");
        }
    }

    public class SavingAccount1 : IAccount1
    {
        public void PrintMessage()
        {
            Console.WriteLine("Deatils of Saving Account");
        }
    }

    class Account1
    {
        public IAccount1? account1 { get; set; } //property 

        public void PrintAccount1()
        {
            account1?.PrintMessage();
        }
    }
}
