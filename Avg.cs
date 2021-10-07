using System;
namespace Day1
{
    class Avg
    {
        static void Main(string[] args)
        {
            int sum = 0, nsum = 0;
            Console.WriteLine("Enter 10 Real Numbers");
            Console.WriteLine("\n\n");
            for(int i=1;i<=10;i++)
            {
                Console.WriteLine("num", i);
                string avg = Console.ReadLine();
                int n = int.Parse(avg);
                if (n >= 0)
                {
                     sum =  sum + n;
                    return sum;
                }
                else
                {
                    nsum = nsum + n;
                    return nsum;

                }
            }
            Console.WriteLine($"{sum}");
            Console.WriteLine($"{nsum}");
        }
    }
}

