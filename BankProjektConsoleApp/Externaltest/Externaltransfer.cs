using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BankProjektConsoleApp;

namespace Externaltest
{
    public class Externaltransfer
    {
        public BankAccount fromAccount { get; set; }
        public string toAccount { get; set; }
        public double Amount { get; set; }

        public Externaltransfer(BankAccount fromAccount,string toAccount,double Amount)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.Amount = Amount;

        }

        public void commitment()
        {
            if (fromAccount.withdraw(Amount))
            {

            }

        }

    }
}
