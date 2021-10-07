using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Not completed date time valid or not program
namespace SampleConApp.Day02
{
    class datevalid
    {

        static bool isValidDate(int year,int month,int day)
        {
            if(year>1 && month<12 && day<31)
            return true;
        }
        static void Main(String[] args)
        {
            Console.WriteLine("Enter the year");
            int year=int.Parse( Console.ReadLine());
            Console.WriteLine("Enter the month ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the day");
            int  day= int.Parse(Console.ReadLine());
            var res = IsValidDate(year, month, day);
            if (res == true)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("inValid");





        }
    }
}
