using System;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get;}
        public Account From { get;}
        public Account To { get;}
        public string Narrative { get;}
        public decimal Amount { get;}

        public Transaction(DateTime date,Account from,Account to,string narrative,decimal amount)
        {
            Date = date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()},{From.Name},{To.Name},{Narrative},{Amount:C}";
        }

    }
}
