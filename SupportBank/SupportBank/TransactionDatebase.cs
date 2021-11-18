using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SupportBank
{
    class TransactionDatebase
    {
        Dictionary<string, Account> Accounts = new Dictionary<string, Account>();
        List<Transaction> Transactions = new List<Transaction>();
        public TransactionDatebase(string path)
        {
            foreach (string line in File.ReadAllLines(path).Skip(1))
            {
                string[] items = line.Split(',');
                string transactionDate = items[0];
                string debter = items[1];
                string creditor = items[2];
                string service = items[3];
                string amount = items[4];
                Account debterAccount;
                Account creditorAccount;
                if (Accounts.ContainsKey(debter))
                {
                    debterAccount = Accounts[debter];
                }
                else
                {
                    debterAccount = new Account(debter);
                    Accounts.Add(debter, debterAccount);
                }

                if (Accounts.ContainsKey(creditor))
                {
                    creditorAccount = Accounts[creditor];
                }
                else
                {
                    creditorAccount = new Account(creditor);
                    Accounts.Add(creditor, creditorAccount);
                }
                
                Transaction currentTransaction = new Transaction(transactionDate, debterAccount, creditorAccount, service, decimal.Parse(amount));
                Transactions.Add(currentTransaction);
                debterAccount.AddTransaction(currentTransaction);
                creditorAccount.AddTransaction(currentTransaction);

                Accounts[debter].Balance -= decimal.Parse(amount);
                Accounts[creditor].Balance += decimal.Parse(amount);
            }
        }

        public void PrintDatebase()
        {
            foreach(var entry in Transactions)
            {
                Console.WriteLine(entry.GetTransactionString());
            }
        }
    }
}
