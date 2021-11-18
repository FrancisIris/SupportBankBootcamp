using System;
using System.Collections.Generic;
using System.Text;

namespace SupportBank
{
    public class Transaction
    {
        public string Date { get; set; }
        public Account From { get; set; }
        public Account To { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string date,Account from,Account to,string narrative,decimal amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }

        public string GetTransactionString()
        {
            return $"{Date},{From.Name},{To.Name},{Narrative},{Amount}";
        }

    }
}
