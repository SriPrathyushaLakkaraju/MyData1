using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//number of stars and rows
namespace SampleConApp.Day02
{
    class numofstars
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter no.of rows you want");
            int n = int.Parse(Console.ReadLine());

            // string[] elements= new string[n];
            string[][] elements = new string[n][];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    

                    Console.Write("*");
                }
            }

        }
    }
}

    
