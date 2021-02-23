using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionList myTransList = new TransactionList();
            myTransList.ReadCsvFile();
        }
    }
}
