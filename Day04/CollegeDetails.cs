using System;
using SampleConApp.Day02;
namespace SampleConApp.Day04
{
    class College
    {
        public string ColName { get; set; }
        public int CS { get; set; }
        public int ES { get; set; }
        public int EE { get; set; }
        public int CI { get; set; }
        public int ME { get; set; }
        public int IT { get; set; }
    }
       
    class CollegeDetails
    {
        static College institute()
        {
            Console.WriteLine("Enter details about your college");
            var name = MyConsole.GetString("Enter College Name");
            var csestrength = MyConsole.GetNumber("Enter total students in CSE");
            var ecestrength = MyConsole.GetNumber("Enter total students in ECE");
            var eeestrength = MyConsole.GetNumber("Enter total students in EEE");
            var civilstrength = MyConsole.GetNumber("Enter total students in CIVIL");
            var Mechstrength = MyConsole.GetNumber("Enter total students in MECHANICAL");
            var ITstrength = MyConsole.GetNumber("Enter total students in IT");
            College ecd = new College
            {
                ColName = name,
                CS = csestrength,
                ES = ecestrength,
                CI = civilstrength,
                ME = Mechstrength,
                IT = ITstrength,
                EE = eeestrength
            };
            return ecd;
        }
        static void Main(string[] args)
        {

            // College cd = new College { ColName = name, CS = csestrength, IT = ITstrength, ME = Mechstrength, CI = civilstrength, EE = eeestrength, ES = ecestrength };
            //Console.WriteLine($"The College name is {cd.ColName}\nBranch wise Strenth of {cd.ColName} is as follows");
            //Console.WriteLine($"Cse Strenth is {cd.CS}\nEce strength is {cd.ES}\nEEE strenth is {cd.EE}\nCivil Strenh is {cd.CI}\nMechanical Strength is {cd.ME}\nIT strength is {cd.IT} ");
            Console.WriteLine("Enter number of colleges you want add");
            int size = int.Parse(Console.ReadLine());
            College[] colleges= new College[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter COllege {i} ");
                colleges[i] = institute();
            }
            foreach(var ecd in colleges)
            {
                Console.WriteLine($" The Colleg name is z{ecd.ColName} contains the brach wise seats as follows");

                Console.WriteLine($"CSE contains {ecd.CS} seats\nEEE contains {ecd.EE} seats\nECE contains {ecd.ES} seats\nCIVIL contains {ecd.CI} seats\nMECHNICAL contains {ecd.ME} seats\nIT contains {ecd.IT} seats");            }
        }
    }
}
