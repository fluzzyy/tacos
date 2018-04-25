using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace BankProjektConsoleApp
{
   public class Program
    {
       private static  List<BankAccount> account = new List<BankAccount>();
       public static void Main(string[] args)
        {
            string filepath = @"c:\Visual Studio Project\tacos\BankProjektConsoleApp\BankAccounts.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                var konton=new BankAccount(words[0],words[1], words[2], double.Parse(words[3]));
                account.Add(konton);              
            }
            // default account       
            //account.Add(new bankAccounts(45678, "Nisse Ströms sparkonto", "Nisse Ström", 45600));
            //account.Add(new bankAccounts(67896, "Olles konto", "Ola Karlsson", 67000));
            //account.Add(new bankAccounts(123456, "Alex's konto", "Alex Gunnarsson", 97000));
            
            var menulopp = true;
            while (menulopp)
            {             
                //Menu
                Console.WriteLine("[1] Lägg till nya konton");
                Console.WriteLine("[2] Insättning ");
                Console.WriteLine("[3] uttag ");
                Console.WriteLine("[4] Lista över konton");
                Console.WriteLine("[5] Överföring");
                Console.WriteLine("[6] Avsluta konto");
                Console.WriteLine("[7] Datumbetalning");
                Console.WriteLine("[8] Visa valv");
                Console.WriteLine("[9] Ta bort datumbetalning");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": addAccount(); break;
                    case "2": Deposit(); break;
                    case "3": Withdraw();break;
                    case "4": accountList();break;
                    case "5": WireTransfer(); break;                      
                    case "6": cancelAccount();break;
                    case "7": DateTransfer();break;
                    case "8": Vault();break;
                    case "9": removeDateTransfer();break;
                }
            }         
        }
        private static void addAccount()
        {
            var running = true;
            while (running)
            {
                Console.Write("Ange nytt kontonummer: ");
                var newNumber = Console.ReadLine();
                Console.Write("Kontots namn: ");
                var newName = Console.ReadLine();
                Console.Write("Ägarens namn: ");
                var newOwner = Console.ReadLine();
                Console.Write("Kontosaldo: ");
                var newBalance = Convert.ToDouble(Console.ReadLine());

                //Adds new account to list
               
                account.Add(new BankAccount(newNumber, newName, newOwner, newBalance));
                
                Console.WriteLine("Lägga till flera konton? J / N");
                var answer = Console.ReadLine();
                if (answer == "n")
                {
                    running = false;
                    Console.Clear();        
                }
                listToFile();
            }
        }
        public static int findAccount(List<BankAccount> accountList,string find)
        {          
            //Console.Write("Ange kontonummer: ");
            //var searchaccount = Console.ReadLine();
            
            for (var i = 0; i < account.Count; i++)
            {
                if (accountList[i].number == find)
                {
                    return i;                 
                }            
            }
            return -1;           
        }
        public static void Deposit()
        {
            Console.Clear();
            Console.Write("Ange kontonummer: ");
            var searchaccount = Console.ReadLine();
            var find = findAccount(account,searchaccount );
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
            Console.Write("Ange kontonummer: ");
            var searchaccount = Console.ReadLine();
            var find = findAccount(account,searchaccount);
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
            Console.Clear();
            Console.WriteLine("----------Alla konton-----------");
            foreach(var s in account)
            {
                Console.WriteLine("Kontonummer: "+s.number);
                Console.WriteLine("Kontonamn: "+s.name);            
                Console.WriteLine("Kontoägare: "+s.owner);
                Console.WriteLine("Saldo: "+s.balance);
                Console.WriteLine();
            }
        }
        private static void listToFile()
        {          
            Console.Clear();
            System.Text.StringBuilder theBuilder = new System.Text.StringBuilder();
            for(int i = 0; i < account.Count; i++)
            {
                theBuilder.Append(account[i].number +" ");
                theBuilder.Append(account[i].name +" ");
                theBuilder.Append(account[i].owner +" ");
                theBuilder.Append(account[i].balance + Environment.NewLine);
            }
            using (var sw = new StreamWriter(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\BankAccounts.txt", false))          
            {
                sw.Write(theBuilder.ToString());
            }
        }
        private static void WireTransfer()
        {
            Console.Clear();
            Console.Write("Från konto: ");
            var fromAccountInput = Console.ReadLine();
            var fromAccount = findAccount(account,fromAccountInput);
            Console.Write("Till Konto ");
            var toAccountInput = Console.ReadLine();
            var toAccount = findAccount(account,toAccountInput);
            Console.Write("Summa: ");
            var amountInput =Convert.ToDouble( Console.ReadLine());
            
            Console.WriteLine("Ny överföring slutförd!" );
            Console.WriteLine();
            Transfer t = new Transfer(account[toAccount] , account[fromAccount], amountInput);
            t.Commit();
            Console.WriteLine("Från kontonummer: "+account[fromAccount].number + " Nytt Saldo: " + account[fromAccount].balance);
            Console.WriteLine("TIll konto: "+account[toAccount].number + " Nytt Saldo: "+ account[toAccount].balance);                        
        }
        private static void cancelAccount()
        {
            Console.Write("Ange konto att ta bort: ");
            var removeAccountInput = Console.ReadLine();
            var remove = findAccount(account,removeAccountInput);
            account.RemoveAt(remove);
            string content = "";
            foreach (var a in account)
            {
                content += a.toString() + Environment.NewLine;

            }
            File.WriteAllText(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\BankAccounts.txt", content);
            Console.WriteLine("Konto avslutat!");
            Console.ReadLine();
        }
        private static void DateTransfer()
        {
            DateTime datum=new DateTime(2018,04,17);           
            Console.Clear();
            Console.Write("Från konto: ");
            var fromAccountInputDate = Console.ReadLine();
            var fromAccountDate = findAccount(account,fromAccountInputDate);
            Console.Write("Till Konto: ");
            var toAccountInputDate = Console.ReadLine();
            var toAccountDate = findAccount(account,toAccountInputDate);
            Console.Write("När(YYYY/MM/DD):  ");
            var inputDate = Console.ReadLine();
            DateTime datumet = DateTime.ParseExact(inputDate, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture); //ingen aning vad detta är
            DateTime DateNow = DateTime.Now;

            Console.Write("Summa: ");
            var amountTransfer = Convert.ToDouble(Console.ReadLine());
            if (datumet.Date>DateNow.Date)
            {
                Console.WriteLine("Överföring kommer slutföras den: "+datumet);
                dateTransferToFile(fromAccountDate,toAccountDate,inputDate,amountTransfer);
            }
            else
            {
                Transfer transfer = new Transfer(account[fromAccountDate],account[toAccountDate],amountTransfer);
                transfer.Commit();
            }
        }
        private static void Vault()
        {
            Console.Clear();
            double total = 0;
            foreach (var konto in account)
            {
                total += konto.balance;            
            }
            Console.WriteLine("Total summa i valvet: " + total);
        }

        private static void dateTransferToFile(int fromAccountDate, int toAccountDate,string inputDate, double amountTransfer)
        {
            Console.Clear();
            System.Text.StringBuilder theDateBuilder = new System.Text.StringBuilder();
           
                theDateBuilder.Append(fromAccountDate + " ");
                theDateBuilder.Append(toAccountDate + " ");
                theDateBuilder.Append(inputDate+ " ");
                theDateBuilder.Append(amountTransfer + Environment.NewLine);
            using (var sw2 = new StreamWriter(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransfer.txt", true))
            {
                sw2.Write(theDateBuilder.ToString());
            }
        }
        private static void removeDateTransfer()
        {
            Console.Clear();          
            Console.Write("Ange konto för att ta bort dess datumbetalning: ");
            var removeInput = Console.ReadLine();
            string numberline = "";
            using (StreamReader reader =
                new StreamReader(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransfer.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransferDelete.txt"))
                {
                    while ((numberline = reader.ReadLine()) != null)
                    {
                       if(string.Compare(numberline,removeInput)==0)
                           continue;
                        writer.WriteLine(numberline);
                    }
                }
            }
            if (File.Exists(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransfer.txt"))
            {
                File.Delete(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransfer.txt");
            }
            File.Move(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransferDelete.txt", @"c:\Visual Studio Project\tacos\BankProjektConsoleApp\DateTransfer.txt");    
                       
        }
        
    }
}
