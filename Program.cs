using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionList myTransList = new TransactionList();
            myTransList.ReadCsvFile();
            AccountList myAccList = new AccountList();
            myAccList.MakeAccList(myTransList.TransList);

            string option;
            Console.WriteLine("Would you prefer to list all transactions (All) or to specify username (Firstname Last Initial)?: ");
            option = Console.ReadLine();
            if (option == "All") {
                AccountListAll myAccListAll = new AccountListAll();
                myAccListAll.DisplayAccounts(myAccList.AccList);
            } else {
                AccountListName myAccListName = new AccountListName();
                myAccListName.DisplaySingleAccount(myAccList.AccList, option);
            }
           
        }
    }
}
