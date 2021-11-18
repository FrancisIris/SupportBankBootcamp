using System;
using System.Collections.Generic;

namespace SupportBank
{
    public class Account
    {
        public string Name { get;}
        public decimal Balance { get; set; }

        private List<Transaction> Transactions { get; }
        public Account(string name)
        {
            Name = name;
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(Transaction transaction)
        {
            Balance = transaction.From == this ? Balance - transaction.Amount : Balance + transaction.Amount;
            Transactions.Add(transaction);
        }

        public void PrintTransactions()
        {
            foreach(var transaction in Transactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }
    }
}
