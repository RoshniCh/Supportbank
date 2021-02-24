using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SupportBank
{
    class AccountListAll
    {
        public void DisplayAccounts(List<Account> AccountHistory)
        {
            Console.WriteLine("Name Amount");
            foreach (Account Acc in AccountHistory)
            {   double amount = 0;
                foreach (var InTr in Acc.IncomingTransactions) {
                    amount += InTr.Amount; }
                foreach (var OTr in Acc.OutgoingTransactions) {
                    amount -= OTr.Amount; }
                Console.WriteLine(Acc.Name + " " + amount); 
            };
        } 
          
    }
}