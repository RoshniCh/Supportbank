using System;
using System.IO;
using Newtonsoft.Json;

namespace SupportBank
{
    class Transaction
    {
    public DateTime Date { get; set; }
    [JsonProperty("FromAccount")]
    public string From { get; set; }
    [JsonProperty("ToAccount")]
    public string To { get; set; }
    public string Narrative { get; set; }
    public double Amount { get; set; }
    
    }

}
