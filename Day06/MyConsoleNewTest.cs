using System;


namespace SampleConApp.Day06
{
    class MyConsoleNewTest
    {
        static void Main(string[] args)
        {


            uint num = MyConsoleNew.GetNumber("Enter number");
            double dub = MyConsoleNew.GetDouble("Enter double number");
            var str = MyConsoleNew.GetString("Enter string ");
            var date = MyConsoleNew.GetDate("Enter valid date");
            Console.WriteLine($"{num}\n{dub}\n{str}\n{date.ToShortDateString()}");
        }

    }
}
