using System;
using System.Collections.Generic;
using System.Text;

namespace SupportBank
{
    public class Account
    {
        public string Name { get; set; }
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
            Transactions.Add(transaction);
        }

        public void PrintTransactions()
        {
            foreach(var transaction in Transactions)
            {
                Console.WriteLine(transaction.GetTransactionString());
            }
        }

    }
}
