using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProjektConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // default account
            List<bankAccounts> account = new List<bankAccounts>();
            account.Add(new bankAccounts(45678, "Nisse Ströms sparkonto", "Nisse Ström", 45600));
            account.Add(new bankAccounts(67896, "Olles konto", "Ola Karlsson", 67000));
            account.Add(new bankAccounts(123456, "Alex's konto", "Alex Gunnarsson", 97000));

            //Menu
            Console.WriteLine("[1] Lägg till nya konton");
            Console.WriteLine("[2] Insättning och Uttag");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: addAccount(account); break;
            }
        }

        private static void addAccount(List<bankAccounts>account)
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
                }

            }
        }
    }
}
