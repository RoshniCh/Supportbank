using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SupportBank
{
    class TransactionList
    {
        public List<Transactions> TransList = new List<Transactions>();
        public void ReadCsvFile()
        {

            string path = "C:/Users/roscha/training/support-bank-resources/Transactions2014.csv";
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach(string line in lines) {
                string[] columns = line.Split(',');
                if (columns[0]!="Date") {
                    TransList.Add(new Transactions
                        {
                            Date = Convert.ToDateTime(columns[0]), 
                            // Date = DateTime.ParseExact(columns[0], "dd/mm/yyyy", CultureInfo.InvariantCulture), 
                            From = columns[1],
                            To = columns[2],
                            Narrative = columns[3],
                            Amount = double.Parse(columns[4])
                        }); 
                    
                }    
            }   
            // TransList.ForEach(Console.WriteLine);
            foreach(Transactions tran in TransList)
                {
                Console.WriteLine(tran.Date.ToString("dd/MM/yyyy") +" " + tran.From +" " + tran.To +" " + tran.Narrative +" " + tran.Amount);
                }
        }
    }
}