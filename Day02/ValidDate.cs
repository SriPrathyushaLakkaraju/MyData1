using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day02
{
   
    class ValidDate
    {
        static bool isValidDate(int year, int month, int day)
        {
             if ((year > 1 && year<=9999)  && (month <= 12 && month>=1) && (day <= 31&& day>=1))
                 return true;
             else
                 return false;
            

        }
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter Date to check");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            int yea = dt.Year;
            int mont= dt.Month;
            int da= dt.Day;
            /*Console.WriteLine("Please enter year");
            int yea = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter month");
            int mont = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter day");
            int da = int.Parse(Console.ReadLine());*/
          
            
            if (isValidDate(yea, mont, da) == true)
            {
                Console.WriteLine($"The given day:{da}// Month :{mont} //Year :{yea} is Valid");
            }
            else
                Console.WriteLine($"The given day:{da} //Month :{mont} //Year :{yea} is not valid");
        }
        
    }
}
