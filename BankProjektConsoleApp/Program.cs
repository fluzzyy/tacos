﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankProjektConsoleApp
{
    class Program
    {

       private static  List<bankAccounts> account = new List<bankAccounts>();
        static void Main(string[] args)
        {
            
            // default account       
            //account.Add(new bankAccounts(45678, "Nisse Ströms sparkonto", "Nisse Ström", 45600));
            //account.Add(new bankAccounts(67896, "Olles konto", "Ola Karlsson", 67000));
            //account.Add(new bankAccounts(123456, "Alex's konto", "Alex Gunnarsson", 97000));
            //listToFile();
            bool menulopp = true;
            while (menulopp)
            {
               
                //Menu
                Console.WriteLine("[1] Lägg till nya konton");
                Console.WriteLine("[2] Insättning ");
                Console.WriteLine("[3] uttag ");
                Console.WriteLine("[4] Lista över konton");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": addAccount(); break;
                    case "2": Deposit(); break;
                    case "3": Withdraw();break;
                    case "4": accountList();break;
                }
            }
            
        }
        private static void addAccount()
        {
            bool running = true;
            while (running)
            {
                Console.Write("Ange nytt kontonummer: ");
                var newNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kontots namn: ");
                var newName = Console.ReadLine();
                Console.Write("Ägarens namn: ");
                var newOwner = Console.ReadLine();
                Console.Write("Kontosaldo: ");
                var newBalance = Convert.ToDouble(Console.ReadLine());

                //Adds new account to list
               
                account.Add(new bankAccounts(newNumber, newName, newOwner, newBalance));
                
                Console.WriteLine("Lägga till flera konton? J / N");
                string answer = Console.ReadLine();
                if (answer == "n")
                {
                    running = false;
                    Console.Clear();
                    
                }
                listToFile();

            }
        }
        private static int findAccount()
        {
            Console.Write("Ange kontonummer: ");
            var searchaccount = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].number == searchaccount)
                {
                    return i;                 
                }            
            }
            return -1;
            
        }
        public static void Deposit()
        {
            Console.Clear();
            int find = findAccount();
            Console.WriteLine("Kontonummer: " + account[find].number);
            Console.WriteLine("Kontonamn: "+ account[find].name);
            Console.WriteLine("Kontoägare: " + account[find].owner);
            Console.WriteLine("Saldo: " + account[find].balance);
            Console.Write("Summa för insättning: ");
            double Depositinput = Convert.ToDouble(Console.ReadLine());
            account[find].deposit(Depositinput);
            Console.WriteLine("Nytt saldo: " + account[find].balance);
            Console.WriteLine();           
        }
        public static void Withdraw()
        {
            Console.Clear();
            int find = findAccount();
            Console.WriteLine("Kontonummer: " + account[find].number);
            Console.WriteLine("Kontonamn: "+ account[find].name);
            Console.WriteLine("Kontoägare: " + account[find].owner);
            Console.WriteLine("Saldo: " + account[find].balance);
            Console.Write("Ange summa för uttag: ");
            double WithdrawInput = Convert.ToDouble(Console.ReadLine());
            account[find].withdraw(WithdrawInput);
            Console.WriteLine("Nytt saldo: " + account[find].balance);            
        }
        public static void accountList()
        {
            Console.WriteLine("--------Alla konton-----------");
            foreach(var s in account)
            {
                Console.WriteLine(s.number);
                Console.WriteLine(s.name);            
                Console.WriteLine(s.owner);
                Console.WriteLine(s.balance);
                Console.WriteLine();
            }
        }
        private static void listToFile()
        {          
            Console.Clear();
            System.Text.StringBuilder theBuilder = new System.Text.StringBuilder();
            for(int i = 0; i < account.Count; i++)
            {
                theBuilder.Append(account[i].number );
                theBuilder.Append(account[i].name );
                theBuilder.Append(account[i].owner );
                theBuilder.Append(account[i].balance + Environment.NewLine);
            }
            using (StreamWriter sw = new StreamWriter(@"c:\Visual Studio Project\BankProjektConsoleApp\BankAccounts.txt", true))          
            {
                sw.Write(theBuilder.ToString());
            }
                Console.Read();
        }
         
    }
}
