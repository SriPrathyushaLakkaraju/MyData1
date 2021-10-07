using System;
namespace SampleConApp.Day07
{
    class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException() { /* Default Constructor*/}
        public AccountNotFoundException(string msg) : base(msg) { }
        public AccountNotFoundException(string msg, Exception exception) : base(msg, exception) { }

    }
    class ExceptionHandlingSimple
    {
        
        static void Main(string[] args)
        {
        REDO:
            Console.WriteLine("Enter Number");
            try
            {
                int num = int.Parse(Console.ReadLine());
                // throw new Exception("OPPS Something went Wrong");//throw is like jump statement .After throw if we give Console.WriteLine() it will give an warning.
                throw new AccountNotFoundException("Account not found to delete");
            }
            catch (FormatException)
            {
                Console.WriteLine("Number should be a whole integer value");
                goto REDO;
            }
            catch(OverflowException)
            {
                Console.WriteLine($"Value should be with in {int.MinValue} and {int.MaxValue}");
                goto REDO;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
       