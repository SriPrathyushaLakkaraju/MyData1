using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//fib number at given index
namespace SampleConApp.Day02
{
    class fibatindex
    {
        public static int Fib(int x)
        {
            int n1 = 0, n2 = 1, n3;
            int[] ele = new int[1000];
            ele[0] = 0;ele[1] = 1;
            for (int j = 2; j <= 100; j++)
            {
                n3 = n1 + n2;
                ele[j] = n3;
                n1 = n2;
                n2 = n3;
        
            }

            return ele[x];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter index number");
            int i = int.Parse(Console.ReadLine());
            int res = Fib(i);
            Console.WriteLine($"Fibonacci Number at given index {i} is {res}");
        }
    }
}