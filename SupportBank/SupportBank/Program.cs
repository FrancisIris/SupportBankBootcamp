using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Francis.Jordan\OneDrive\Desktop\Learning\Bootcamp\SupportBankBootcamp\SupportBank\SupportBank\Transactions2014.csv";
            TransactionDatebase db = new TransactionDatebase(path);
            db.PrintDatebase();
        }
    }
}
