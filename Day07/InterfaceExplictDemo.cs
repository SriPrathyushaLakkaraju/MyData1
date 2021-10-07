using System;
namespace SampleConApp.Day07
{
    interface ICustomer
    {
        void create();
    }
     interface IAccount
    {
        void create();
    }
    class CustomerAccount : ICustomer, IAccount
    {
        public void create()
        {
            Console.WriteLine("Create Account and Customer");
        }
        void ICustomer.create()
        {
            Console.WriteLine("Create customer");
        }
        void IAccount.create()
        {
            Console.WriteLine("Create Account");
        }
    }
    class InterfaceExplictDemo
    {
        static void Main(string[] args)
        {
            CustomerAccount ca = new CustomerAccount();
            ca.create();
            IAccount ia = new CustomerAccount();
            ia.create();
            ICustomer ic = new CustomerAccount();
            ic.create();
        }
    }
}
