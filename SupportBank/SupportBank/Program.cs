using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class Program
    {
        private static string path1 = @"C:\Users\Francis.Jordan\OneDrive\Desktop\Learning\Bootcamp\SupportBankBootcamp\SupportBank\SupportBank\Transactions2014.csv";
        private static string path2 = @"C:\Users\Francis.Jordan\OneDrive\Desktop\Learning\Bootcamp\SupportBankBootcamp\SupportBank\SupportBank\DodgyTransactions2015.csv";
        private static TransactionDatebase db;

        static void Main(string[] args)
       {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Users\Francis.Jordan\OneDrive\Desktop\Learning\Bootcamp\SupportBankBootcamp\SupportBank\SupportBank\logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            db = new TransactionDatebase(path2);//change path for which database you want to use
            bool go = true;
            while (go)
            {
                go = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Options:");
            Console.WriteLine("List All - Output all transactions");
            Console.WriteLine("List Users - Output all the user's balances");
            Console.WriteLine("List 'Name' - Output every transaction that the user has been involved with");
            Console.WriteLine("Q - End the program");
            Console.Write(">");
            string userInput = Console.ReadLine();
            Regex regInput = new Regex(@"(?i)List +([\w ]+)|Q\b");
            Match match = regInput.Match(userInput);
            
            if (match.Success)
            {
                switch (userInput.ToLower())
                {
                    case "list all":
                        db.PrintDatabase();
                        break;
                    case "list users":
                        db.PrintBalances();
                        break;
                    case "q":
                        return false;
                    default:
                        try
                        {
                            db.GetAccount(match.Groups[1].Value).PrintTransactions();
                        }
                        catch
                        {
                            Console.WriteLine($"{match.Groups[1].Value} was not valid");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine($"'{userInput}' was not a correct entry.");
            }

            Console.WriteLine("Press Enter to continue");
            Console.Write(">");
            Console.ReadLine();
            return true;
        }
    }
}
