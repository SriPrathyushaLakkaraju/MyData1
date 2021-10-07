using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//String data
namespace SampleConApp.Day02
{
    class stringarray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array");
            int size = int.Parse(Console.ReadLine());
            string[] elements = new string[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter value for the location{i}");
                elements[i] = Console.ReadLine();

            }
            Console.WriteLine("The Given Names are");
            foreach (string element in elements)
            {
                Console.WriteLine(element + "");
            }



        }
    }
}

