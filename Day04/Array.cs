using System;
namespace SampleConApp.Day04
{
    class Array
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());
            int[] numbers = new int[size];
            Console.WriteLine("Enter the numbers in array");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The user given Array is  ");
            foreach(var num in numbers)
            {
                Console.Write("{0}  ",num);
            }
            Console.WriteLine("\n");
        }
    }
}
