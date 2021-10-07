using System;
using SampleConApp.Day02;
namespace SampleConApp.Day04
{
    class Teacher
    {
        public int Tid { get; set; }
        public string Tname { get; set; }
        public string Taddress { get; set; }
        public string Tschool { get; set; }
        public DateTime Tdob { get; set; }
    }
    class TeachersDetails
    {
        static Teacher NewTeacher()
        {
            Console.WriteLine("Enter teacher details");
            int id = MyConsole.GetNumber("Enter teacher id number");
            var name = MyConsole.GetString("Enter teacher name");
            var address = MyConsole.GetString("Enter teacher address");
            var tschool = MyConsole.GetString("Enter name of the school where teacher works");
            var dob = MyConsole.GetDate("Enter date of birth of the teacher");
            Teacher tc = new Teacher { Tid = id, Tname = name, Taddress = address, Tschool = tschool, Tdob = dob };
            return tc;
        }
        static void Main(string[] args)
        {
          
           //Console.WriteLine("Enter number of teachers you want to add");
            int size = MyConsole.GetNumber("Enter number of teachers you want to add");
            Teacher[] tcd = new Teacher[size];
            for (int i = 0; i < size; i++)

            {
                Console.WriteLine($"Enter Teacher {0}");
                tcd[i] = NewTeacher();
            }
            foreach(var tc in tcd)
            {
                Console.WriteLine($"The Giver teacher details are as follows\nteacher id is {tc.Tid}\nteacher name is {tc.Tname}\nteacher address is {tc.Taddress}\nteacher school name is {tc.Tschool}\nteacher dob is {tc.Tdob.ToShortDateString()}\nteacher age is{DateTime.Now.Year-tc.Tdob.Year}");        }
            }
        }
         
}
