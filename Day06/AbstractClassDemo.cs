using System;
using SampleConApp.Day07;
namespace SampleConApp.Day06
{
    abstract class Account
    {
        public override string ToString()
        {
            return $"The name:{Name}\nThe Balance:{Balance:C}\n";
        }
        public uint AccountNum { get; set; }
        public string Name { get; set; }
        public double Balance { get; private set; } = 5000;
        public void credit(double amount)
        {
            Balance += amount;
        }
        public void debit(double amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("Invalid Funds");
                return;
            }
            Balance -= amount;
        }
        public abstract void CalculateInterest();
    }
    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double principle = Balance;
            double rate = 7 / 100;
            double term = 0.25;
            double interest = principle * rate * term;
            credit(interest);

        }
    }
    class FDACCount : Account
    {
        public override void CalculateInterest()
        {
            int term = 5;//years
            double rate = 8.5 / 100;//rate of interest
            double fixedamount = Balance;//current balance
            double interest = term * rate * fixedamount;
            credit(interest);
        }
    }
    class RDAccount : Account
    {
        public override void CalculateInterest()
        {
            int term = 5 * 12;
            double rate = 7.5 / 100;
            double monthpayment = 5000;
            double interest = term * monthpayment * rate;
            credit(interest);
        }
    }
    enum AccountType
    {
        SB, FD, RD
    }
    static class AccountManager
    {
        public static Account CreateAccount(AccountType type)
        {
            Account acc = null;
            switch (type)
            {
                case AccountType.SB:
                    acc = new SBAccount();
                    break;
                case AccountType.RD:
                    acc = new RDAccount();
                    break;
                case AccountType.FD:
                    acc = new FDACCount();
                    break;

            }
            return acc;
        }
    }

    [Serializable]
    public class AccountCreationFailedException : ApplicationException
    {
       public AccountCreationFailedException() { }
        public AccountCreationFailedException(string message) : base(message) { }
        public AccountCreationFailedException(string message, Exception inner) : base(message, inner) { }
        protected AccountCreationFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class BankingApp
    {
        const byte size = 10;
        Account[] accounts = new Account[size];//limitation of Arrays, we are fixing the size.
        public virtual void AddNewAccount(Account acc)
        {
            //Using for loop, find the first occurance of null in the array and set the value in that location. Immediately exit the function after the setting is done. Else U can continue the loop. 
            for (int i = 0; i < size; i++)
            {
                if (accounts[i] == null)
                {
                    accounts[i] = acc;
                    return;
                }
                else continue;
            }
            throw new AccountCreationFailedException("No more exceptions could be created");
        }
        public virtual void DeleteAccount(int id)
        {
            for (int i = 0; i < size; i++)
            {
                if ((accounts[i] != null) && (accounts[i].AccountNum == id))
                {
                    accounts[i] = null;
                    return;
                }
            }
            throw new AccountNotFoundException($"Account with {id} not found to delete");
        }
        public virtual void UpdateCustomer(Account acc)
        {
            for (int i = 0; i < size; i++)
            {
                if ((accounts[i] != null) && (accounts[i].AccountNum == acc.AccountNum))
                {
                    accounts[i] = acc;
                    return;
                }
            }
        }
        public virtual Account[] GerAccountDetails()
        {
            return accounts;
        }
    }
    class AbstractClassDemo
    {
        const string menu = "----------BANKING APP--------------------\nTO ADD ACCOUNT--------->PRESS 1\nTO DELETE ACCOUNT------------->PRESS 2\nTO UPDATE ACCOUNT-------->PRESS 3\nTO FIND ACCOUNT DETAILS---->PRESS 4\n";
        static BankingApp app = new BankingApp();//create object for interaction
        static void initialize()
        {
            app.AddNewAccount(new SBAccount { AccountNum = 12345, Name = "sri" });
            app.AddNewAccount(new SBAccount { AccountNum = 12346, Name = "Prashanth" });
            app.AddNewAccount(new SBAccount { AccountNum = 12347, Name = "Prathyusha" });
            app.AddNewAccount(new SBAccount { AccountNum = 12348, Name = "Anusha" });
            app.AddNewAccount(new SBAccount { AccountNum = 12349, Name = "Aparna" });
        }
        static void Main()
        {
            initialize();
            bool processing = true;
            do
            {
                var choice = MyConsoleNew.GetNumber(menu);
                processing = ProcessMenu(choice);
            } while (processing);
        }
        private static bool ProcessMenu(uint choice)
        {
            switch (choice)
            {
                case 1:
                    addAccountDetails();
                    return true;
                case 2:

                    DeleteAccount();
                    return true;
                case 3:
                    UpdateAccount();
                    Console.WriteLine("To be implemented in the next version");
                    return true;
                case 4:
                    findingAccountFunc();
                    return true;
            }
            return false;//default value
        }

        private static void UpdateAccount()
        {
            var records = app.GerAccountDetails();
            var num = MyConsoleNew.GetNumber("Enter the name or partial name to find");
            foreach (var acc in records)
            {
                if (acc != null && acc.AccountNum==num)
                {
                    Console.WriteLine(acc);//Implicitly calls the ToString Method of the object
                }
            }
        }

        private static void addAccountDetails()
        {
            //create the type of account requested by the user
            
            Console.WriteLine("Enter the type of account u want to create as SB,FD or RD");
            var type = (AccountType)Enum.Parse(typeof(AccountType), Console.ReadLine());
            var acc = AccountManager.CreateAccount(type);
            //set the details for the account
            acc.AccountNum = MyConsoleNew.GetNumber("enter the account number for the customer");
            acc.Name = MyConsoleNew.GetString("Enter Name");
            double amount = MyConsoleNew.GetDouble("Enter the initial amount for deposit");
            acc.credit(amount);
            //call the AddNewAccount function and pass the object into the banking repository
            try
            {
                app.AddNewAccount(acc);

                Console.WriteLine("The Account of the type {0} is added to database", type);
            }
            catch (AccountCreationFailedException ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        private static void DeleteAccount()
        {
            var id = (int)MyConsoleNew.GetNumber("Enter id to delete");
            try
            {
                app.DeleteAccount(id);
                Console.WriteLine("The Account of {0} is deleted successfully.", id);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            
        }
        private static void findingAccountFunc()
        {
            //get all records from the banking object
            var records = app.GerAccountDetails();
            //ask the user name or partial name to find
            var name = MyConsoleNew.GetString("Enter the name or partial name to find");
            //Display the list of all the matching accounts with the name
            foreach (var acc in records)
            {
                if (acc != null && acc.Name.Contains(name))
                {
                    Console.WriteLine(acc);//Implicitly calls the ToString Method of the object
                }
            }
        }
    }
}
    



        

