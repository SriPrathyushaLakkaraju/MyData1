using System;
//Prime Number 
namespace SampleConApp.Day02
{
    class isprimeornot
    {
        static bool isPrimeNumber(int num)
        {
            int a = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0) { a++; }

            }
            if (a == 2)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int n = int.Parse(Console.ReadLine());
            var value = isPrimeNumber(n);
            if (value == true)
                Console.WriteLine("prime");
            else
                Console.WriteLine("not prime");
        }
    }
}
