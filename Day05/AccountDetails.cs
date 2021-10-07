using System;
using SampleConApp.Day02;
namespace SampleConApp.Day05
{
    class Account
    {
        public double AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; } 

        public void credit(double amount)
        {
            Balance += amount;
        }
        public void debit(double amount)
        {
            if (Balance < amount)
                Console.WriteLine("Indufficient Balance");
            else
                Balance -= amount;
        }
    }
    class SBAccount : Account { }
    class FDAccount : Account { }
    class RDAccount : Account { }

    static class AccountManager
    {
        public static Account CreateAccount(string accounttype)
        {
            Account acc = null;
            switch (accounttype)
            {
                case "SB":
                    acc = new SBAccount();
                    break;
                case "RD":
                    acc = new SBAccount();
                    break;
                case "FD":
                    acc = new SBAccount();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;

            }
            return acc;
        }
    }
    class AccountDetails
    {
        static Account CreateUserAccount()
        {
            Console.WriteLine("Enter Account type SB or FD or RD\nIf you enter any other option it will be considered " +
                "as invali accounttype");
            string accountname = Console.ReadLine();
            Account obj = AccountManager.CreateAccount(accountname);
            return obj;
        }
        static Account getDetails()
        {
            Account ad = CreateUserAccount();
            var num = MyConsole.GetDouble("enter account number");
            var name = MyConsole.GetString("enter account holder number");
            var credit = MyConsole.GetDouble("enter minimum balance number");
            Account ac = new Account { AccountNumber = num, Name = name, Balance = credit };
            return ac;
        }
        static void Main(string[] args)
        {
            Account ac1 = getDetails();
            Account ac2 = getDetails();
            Account ac3 = getDetails();
            Account ac4 = getDetails();
            Account ac5 = getDetails();
        }
    }
}



       




