using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektConsoleApp
{
   public class ExternalTransfer
    {
        public BankAccount externalFrom { get; set; }
        public BankAccount externalTo { get; set; }
        public double externalBalance { get; set; }

        public ExternalTransfer(BankAccount externalFrom,BankAccount externalTo,double externalBalance)
        {
            this.externalFrom = externalFrom;
            this.externalTo = externalTo;
            this.externalBalance = externalBalance;
        }

        public void commit()
        {
            Console.WriteLine(externalFrom.balance);
            externalFrom.withdraw(externalBalance);
            Console.WriteLine(externalFrom.balance);
            Console.Read();

        }


    }
}
