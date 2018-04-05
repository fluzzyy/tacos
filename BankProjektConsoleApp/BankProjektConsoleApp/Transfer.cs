using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektConsoleApp
{
   public class Transfer
   {
       private bankAccounts to;
       private bankAccounts from;
       private double Amount;

       public Transfer(bankAccounts to, bankAccounts from, double Amount)
       {
           this.to = to;
           this.from= from;
           this.Amount = Amount;
       }

       public void Commit()
       {

           if (!(Amount > from.balance))
           {
               to.deposit(Amount);
            }
           //to.deposit(Amount);
           from.withdraw(Amount);
       }


   }
}
