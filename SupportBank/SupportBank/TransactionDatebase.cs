using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SupportBank
{
    class TransactionDatebase
    {
        public Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
        public List<Transaction> Transactions = new List<Transaction>();
        public TransactionDatebase(string path)
        {
            foreach (string line in File.ReadAllLines(path).Skip(1))
            {
                string[] items = line.Split(',');
                DateTime transactionDate;
                if(!DateTime.TryParse(items[0], out transactionDate))
                {
                    //say something about datetime issue
                    continue;
                }
                string debter = items[1];
                string creditor = items[2];
                string service = items[3];
                decimal amount;
                if (!decimal.TryParse(items[4], out amount))
                {
                    //say something about amount type issue
                    continue;
                }

                Accounts.TryAdd(debter, new Account(debter));

                Accounts.TryAdd(creditor, new Account(creditor));

                Transaction currentTransaction = new Transaction(transactionDate, Accounts[debter], Accounts[creditor], service, amount);
                Transactions.Add(currentTransaction);
                Accounts[debter].AddTransaction(currentTransaction);
                Accounts[creditor].AddTransaction(currentTransaction);

                Accounts[debter].Balance -= amount;
                Accounts[creditor].Balance += amount;
            }
        }

        public void PrintDatebase()
        {
            foreach(var entry in Transactions)
            {
                Console.WriteLine(entry.ToString());
            }
        }
        public Account GetAccount(string name)
        {
            return Accounts[name];
        }
        public void PrintBalances()
        {
            foreach(var account in Accounts)
            {
                Console.WriteLine($"Name:{account.Value.Name} ### Balance:{account.Value.Balance}"); 
            }
        }
    }
}
