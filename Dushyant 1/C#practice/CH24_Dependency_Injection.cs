using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH24_Dependency_Injection
    {
        ///<summary>
        ///
        /// **** TIght Coupling *****
        /// 
        /// Tight coupling is when a group of classes are highly dependent on one another.
        /// 
        /// Disadvantage : 
        /// The scenario arises when a class assumes too many responsibility, or when one concern is spread over many classes rather than having its own class
        /// 
        /// Difficult to maintain 
        /// Difficult to test
        /// 
        /// ****** Loose Coupling 
        /// Loose coupling means that the clsses are independent of each other
        /// 
        /// Advantage :
        /// 
        /// Loose coupling is achived by means of a design that promotes single-responsibility and separation of concern 
        /// 
        /// Easy to maintain
        /// Easy to test 
        /// Imporant point 
        /// 
        /// Dependency injection achived using interfaces
        /// interface are a powerful tool use for decoupling 
        /// Classes can communicate through interfaces rather than other concrete classes
        /// 
        /// 
        /// **** Dependency Injection ******
        /// 
        /// Dependency Injection(DI)  is software pattern 
        /// 
        /// Dependency Injection is basically proving the objects that can object need , istead of having it construcot the object themselves
        /// 
        /// Dependency Injection is a technique wherebby one object supplies the dependecies of another object 
        /// </summary>
    }

    /*// Tightly Coupled Code 

    public class CurrentAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Deatils of Current Account");
        }
    }
   public class SavingAccount
    {
        public void PrintDetails()
        {
            Console.WriteLine("Deatils of Saving Account");
        }
    }

   public class Account
    {
        CurrentAccount ca = new CurrentAccount();
        SavingAccount sa = new SavingAccount();

        public void PrintAccount()
        {
            ca.PrintDetais();
            sa.PrintDetais();
        }
    }*/


   // Lossely Coupled Code
    public interface IAccount
    {
        void PrintDetais();
    }

    public class CurrentAccount : IAccount
    {
        public void PrintDetais()
        {
            Console.WriteLine("Deatils of Current Account");
        }
    }
    public class SavingAccount : IAccount
    {
        public void PrintDetais()
        {
            Console.WriteLine("Deatils of Saving  Account");
        }
    }

    public class Account
    {
        private IAccount account; // creating pricate variable 

        public Account(IAccount account)// parameterized constructor 
        {
            this.account = account;
        }

        public void PrintAccount()
        {
            account.PrintDetais();
        }
    }
}
