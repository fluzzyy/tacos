using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using BankProjektConsoleApp;
using S22.Imap;


namespace Externaltest
{
    class ExternalText
    {
       private static List<BankAccount> account = new List<BankAccount>();
        static void Main(string[] args)
        {
           sendMail();
            readMail();

            string filepath = @"c:\Visual Studio Project\tacos\BankProjektConsoleApp\BankAccounts.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');

                var konton = new BankAccount(words[0], words[1], words[2], double.Parse(words[3]));
                account.Add(konton);
            }
            ExternalTransfer a = new ExternalTransfer(account[0],account[1],100);
            a.commit();
            listToFile();
        }
        private static void listToFile()
        {
            Console.Clear();
            System.Text.StringBuilder theBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < account.Count; i++)
            {
                theBuilder.Append(account[i].number + " ");
                theBuilder.Append(account[i].name + " ");
                theBuilder.Append(account[i].owner + " ");
                theBuilder.Append(account[i].balance + Environment.NewLine);
            }
            using (var sw = new StreamWriter(@"c:\Visual Studio Project\tacos\BankProjektConsoleApp\BankAccounts.txt", false))
            {
                sw.Write(theBuilder.ToString());
            }
        }
        private static void sendMail()
        {
            Console.Write("Från konto: ");

            
            MailMessage sendMail=new MailMessage("tacobanken@gmail.com", "tryggbank@gmail.com");
            SmtpClient client = new SmtpClient(); 
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials=new NetworkCredential("tacobanken@gmail.com","apan1234");
            client.EnableSsl = true;
            sendMail.Subject = "Ny överföring";
            sendMail.Body = "apaaa";
            client.Send(sendMail);
        }

        private static void readMail()
        {
            ImapClient imap = new ImapClient("imap.gmail.com", 993, "tacobanken@gmail.com", "apan1234",
                AuthMethod.Login, true);
            {
                IEnumerable<uint> uids = imap.Search(SearchCondition.Unseen());
                IEnumerable<MailMessage> messages = imap.GetMessages(uids);

                foreach (MailMessage m in messages)
                {
                    Console.WriteLine(m.Subject);
                    Console.WriteLine(m.Body);                 
                }
                
            }


        }
    }
}
