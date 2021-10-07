using System;
namespace SampleConApp.Day06
{
    class MyConsoleNew
    {
        public static uint GetNumber(String question)
        {
            uint res;
        RETRY://label
            Console.WriteLine(question);
            if (!uint.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Number is Invalid,Number should be whole number as integer and should be with in the range of {0} and {1} ", 0, uint.MaxValue);

                goto RETRY;
            }
            return res;
        }
        public static string GetString(String question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static double GetDouble(String question)
        {
            double res;
        RETRY://label
            Console.WriteLine(question);
            if (!double.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Number is Invalid,Number should be whole number as integer and  should be with in the range of {0} and {1} ", double.MinValue, double.MaxValue);
                goto RETRY;
            }
            return res;
        }
        public static DateTime GetDate(string question)
        {
            DateTime res;
        TRYAGAIN:
            Console.WriteLine(question);
            if (!DateTime.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Given value is not a valid Date");
                goto TRYAGAIN;
            }
            return res;
        }
    }
}