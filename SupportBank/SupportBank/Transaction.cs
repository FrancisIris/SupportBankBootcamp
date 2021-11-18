using System;
using System.Collections.Generic;
using System.Text;

namespace SupportBank
{
    public class Transaction
    {
        public string Date { get;}
        public Account From { get;}
        public Account To { get;}
        public string Narrative { get;}
        public decimal Amount { get;}

        public Transaction(string date,Account from,Account to,string narrative,decimal amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date},{From.Name},{To.Name},{Narrative},{Amount}";
        }

    }
}
