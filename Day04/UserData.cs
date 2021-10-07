using System;
namespace SampleConApp.Day04
{
    class UserData
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your age");
            string age = Console.ReadLine();
            Console.WriteLine("Name is {0}\nAddress is {1}\nAge is {2}", name, address, age);
        }
    }
}
