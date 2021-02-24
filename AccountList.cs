using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SupportBank
{
    class AccountList
    {
        public List<Account> AccList = new List<Account>();
        public void MakeAccList(List<Transaction> TransactionHistory)
        {
            // for each entry in transaction history - read the list element
            foreach (var tran in TransactionHistory)
            {
                //check if already present in account list by matching name

                if (!AccList.Any(Account => Account.Name == tran.To))
                {
                    var incomingTrans = TransactionHistory.Where(p => p.To == tran.To).ToList();
                    var outgoingTrans = TransactionHistory.Where(p => p.From == tran.To).ToList();
                    AccList.Add(new Account
                    {
                        Name = tran.To,
                        IncomingTransactions = incomingTrans,
                        OutgoingTransactions = outgoingTrans
                    });
                }
                if (!AccList.Any(Account => Account.Name == tran.From)) {
                    var incomingTrans = TransactionHistory.Where(p => p.To == tran.From).ToList();
                    var outgoingTrans = TransactionHistory.Where(p => p.From == tran.From).ToList();
                    AccList.Add(new Account
                    {
                        Name = tran.From,
                        IncomingTransactions = incomingTrans,
                        OutgoingTransactions = outgoingTrans
                    });
                }
            }
            // foreach (Account Acc in AccList)
            // {   

            //     Console.WriteLine(Acc.Name); 
            //     foreach (var InTr in Acc.IncomingTransactions) {
            //         Console.WriteLine(InTr.From +" "+ InTr.To + " " + InTr.Narrative);
            //     };
            // }
        } 
          
    }
}