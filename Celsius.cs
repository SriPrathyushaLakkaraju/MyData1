using System;

namespace Day1
{
    class Celsius
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Celsius degree value");
            string name = Console.ReadLine();
            int d = int.Parse(name);
            int Kelvin = d + 273;
            Console.WriteLine("Kelvin for given Celsius is " + Kelvin);
            int fh = d* 18 / 10 + 32;
            Console.WriteLine("Fahrenheit for given Celsius is " + fh);
        }
    }
}
          
