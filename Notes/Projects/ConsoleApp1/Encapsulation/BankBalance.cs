using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Encapsulation
{
    internal class BankBalance
    {
        // using Methods 

        private decimal balance;

        public void Balance(decimal initialbalance)
        {
            balance = initialbalance;
            Console.WriteLine($"Initial balance {balance}");
        }

        public void Deposite(decimal amount)
        {
            if(amount >0)
            {
                balance += amount;
                Console.WriteLine($"After Deposite Balance is {balance}");
            }
            else
            {
                Console.WriteLine($"Please Deposite Amount Again ");
            }
        }

        public void Withdraw(decimal amount)
        {
            if(balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"After Withdrawing Balance {balance}");
            }
            else
            {
                Console.WriteLine("Insufficeint Balance ");
            }
        }
    }

}
