using System;
namespace Day1
{
    class MPTable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number");
            string n = Console.ReadLine();
            int nu=int.Parse(n);
            Console.WriteLine(" Multiplication Table for " + nu + "is");
            Object data = 1;
            int i = (int)data;
            while (i<=10)
            {
                
               
                    //Console.WriteLine(" Multiplication Table for " + nu + "is");
                    int k = nu * i;
                    Console.WriteLine(nu + "*" + i + "=" + k);
                    i++;

      
            }


        }
    }
}
