using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SupportBank
{
    class AccountListName
    {
        public void DisplaySingleAccount(List<Account> AccountHistory, string UserName)
        {
            Console.WriteLine("Date, From, To, Narrative,Amount");
            foreach (Account Acc in AccountHistory)
            {  
                if (Acc.Name == UserName) {
                    Console.WriteLine(Acc.Name); 
                    foreach (var InTr in Acc.IncomingTransactions) {
                    Console.WriteLine(InTr.Date.ToString("dd/MM/yyyy") + " " + InTr.From +" "+ InTr.To + " " + InTr.Narrative + " " +InTr.Amount );
                    };

                    foreach (var OTr in Acc.OutgoingTransactions) {
                    Console.WriteLine(OTr.Date.ToString("dd/MM/yyyy") + " " + OTr.From +" "+ OTr.To + " " + OTr.Narrative + " " +OTr.Amount );
                    };
                }
            }
        }
    } 
}
