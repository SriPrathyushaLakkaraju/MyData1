using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// sort three numbers
namespace SampleConApp.Day02
{
    class sortthreenums
    {
        public static void SortThreeNumbers(int a, int b, int c)
        {
            if (a <= b && a <= c)
            {

                if (b <= c)
                    Console.WriteLine($"{a} {b} {c}");
                else
                    Console.WriteLine($"{a} {c} {b}");
            }
            else if (b <= a && b <= c)
            {

                if (a <= c)
                    Console.WriteLine($"{b} {a} {c}");
                else
                    Console.WriteLine($"{b} {c} {a}");
            }
            else
            {
                if (a <= b)
                    Console.WriteLine($"{c} {a} {b}");
                else
                    Console.WriteLine($"{c} {b} {a}");
            }
        }

            static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 numbers");
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            SortThreeNumbers( d, e, f);

        }
    }
}