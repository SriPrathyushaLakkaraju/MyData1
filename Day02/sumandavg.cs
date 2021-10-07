using System;
// Average of Positives and Negatives
namespace SampleConApp.Day02
{
    class sumandavg
    {
        static void Main(String[] args)
        {
            int num, sum = 0, nsum = 0;
            double avg, avg2;
            Console.WriteLine("Enter 10 real numbers");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"number {i}");
                num = int.Parse(Console.ReadLine());
                if (num >= 0)
                    sum = sum + num;
                else
                    nsum = nsum + num;

            }
            avg = sum / 10.0;
            avg2 = nsum / 10.0;
            Console.WriteLine($"sum is {sum} and avg is {avg}");
            Console.WriteLine($"sum is {nsum} and avg is {avg2}");

        }
    }
}