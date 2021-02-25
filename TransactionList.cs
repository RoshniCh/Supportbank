using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using NLog;
using NLog.Config;
using NLog.Targets;
using Newtonsoft.Json;

namespace SupportBank
{
    class TransactionList
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public List<Transaction> TransList = new List<Transaction>();

        public void ReadCsvFile(string path)
        {
            var lines = File.ReadAllLines(path).Skip(1);
            int counter = 1;
            foreach(string line in lines) {
                counter += 1;
                string[] columns = line.Split(',');
                try {
                TransList.Add(new Transaction
                    {
                        Date = Convert.ToDateTime(columns[0]), 
                        From = columns[1],
                        To = columns[2],
                        Narrative = columns[3],
                        Amount = double.Parse(columns[4])
                    }); 
                }
                catch (Exception e) {
                        Logger.Error("Invalid data entry at line " + counter + " of the CSV file.");
                        Logger.Error(columns[0] + " " +columns[1] + " " + columns[2] + " " + columns[3] + " " + columns[4]);
                        // throw e;
                        Logger.Error(e);
                        Console.WriteLine("Errors in CSV file, please check logger for details!"); 
                }
            }   
            // TransList.ForEach(Console.WriteLine);
            // foreach(Transaction tran in TransList)
            //     {
            //     Console.WriteLine(tran.Date.ToString("dd/MM/yyyy") +" " + tran.From +" " + tran.To +" " + tran.Narrative +" " + tran.Amount);
            //     }
        }
        public void ReadJsonFile(string path) {
            // using (StreamReader r = new StreamReader(path))
            // {
                // string json = r.ReadToEnd();
                string json = File.ReadAllText(path);
                List<Transaction> TransList = JsonConvert.DeserializeObject<List<Transaction>>(json);
                // foreach(var tran in TransList)
                // {
                // Console.WriteLine(tran.Date.ToString("dd/MM/yyyy") +" " + tran.From+" " + tran.To +" " + tran.Narrative +" " + tran.Amount);
                // }


            // }

        }
    }
}