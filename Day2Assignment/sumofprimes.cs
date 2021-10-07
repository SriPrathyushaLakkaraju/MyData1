using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SampleConApp.Day02
{
    class sumofprimes
    {
        public static int SumOfPrimes(int from, int to)
        {
            int sum = 0,nsum=0,K=0;
            for(int i=from;i<=to;i++)
            {
                int c = 0;
                for(int j=1;j<=100;j++)
                {
                    if (i % j == 0)
                    {
                        c++;
                    }
                    else
                        K++;
                }
                if ( c == 2)
                    sum = sum + i;
                else
                    nsum = nsum + from;
                    
            }
       
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter from and to numbbers");
            int f = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int res=SumOfPrimes(f, t);
              Console.WriteLine($"Sum of primes between {f} and {t} is {res}");
        }
    }
}
