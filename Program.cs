using System;
using NLog;
using NLog.Config;
using NLog.Targets;


namespace SupportBank
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            // Logger.Error("test");
            string fileExtension = "";
            Console.WriteLine("Read json or csv file?");
            fileExtension = Console.ReadLine();
            TransactionList myTransList = new TransactionList();
            
            if (fileExtension == "csv") {
                string path = "C:/Users/roscha/training/support-bank-resources/DodgyTransactions2015.csv";
                myTransList.ReadCsvFile(path);
            } else {
                string path = "C:/Users/roscha/training/support-bank-resources/Transactions2013.json";
                myTransList.ReadJsonFile(path);
            }

            AccountList myAccList = new AccountList();
            myAccList.MakeAccList(myTransList.TransList);

            string option;
            Console.WriteLine("Would you prefer to list all transactions (All) or to specify username (Firstname Last Initial)?: ");
            option = Console.ReadLine();
            if (option == "All") {
                // AccountListAll myAccListAll = new AccountListAll();
                // myAccListAll.DisplayAccounts(myAccList.AccList);
                myAccList.DisplayAccounts();
            } else {
                // AccountListName myAccListName = new AccountListName();
                // myAccListName.DisplaySingleAccount(myAccList.AccList, option);
                myAccList.DisplaySingleAccount(option);
            }
           
        }
    }
}
