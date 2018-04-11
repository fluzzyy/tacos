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
       private BankAccount to;
       private BankAccount from;
       private double Amount;

       public Transfer(BankAccount to, BankAccount from, double Amount)
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
