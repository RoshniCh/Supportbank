using System;
using System.IO;

namespace SupportBank
{
    class Transaction
    {
    public DateTime Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Narrative { get; set; }
    public double Amount { get; set; }
    
    }

}
