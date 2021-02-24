using System;
using System.IO;
using System.Collections.Generic;

namespace SupportBank
{
    class Account
    {
    public string Name { get; set; }
    public List<Transaction> IncomingTransactions { get; set; }
    public List<Transaction> OutgoingTransactions { get; set; }
    }
}

