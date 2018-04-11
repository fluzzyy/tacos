﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektConsoleApp
{
    public class BankAccount
    {
        public string number { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public double balance { get; set; }

        public BankAccount(string number, string name, string owner, double balance)
        {
            this.number = number;
            this.name = name;
            this.owner = owner;
            this.balance = balance;          
        }
        public void deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount");
               
                
            }
            else
            {
                this.balance = this.balance + amount;
            }
        }
        public void withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("uttag medjes ej!");
            }
            else
            {
                this.balance = this.balance - amount;

                Console.WriteLine("Uttag medjes!");
            }
        }

        public String toString()
        {
            return number + " " + name + " " + owner + " " + balance;
        }
    }
}
