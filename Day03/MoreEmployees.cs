using System;
namespace SampleConApp.Day03
{
    class Emp
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public DateTime Dob { get; set; }
    }
    class MoreEmployees
    {
        private const int cstSize = 10;
        private static Customer[] _customers = new Customer[cstSize];

        static void Main(string[] args)
        {
            
            var e = new Emp[5];
            e[0] = new Emp{ EmpId=1, EmpName = "Sri     ", EmpAddress = "Mysore", Dob = DateTime.Parse("12/4/1999")};
            e[1] = new Emp { EmpId = 2, EmpName = "Prashanth", EmpAddress = "Mysore", Dob = DateTime.Parse("12/4/1999") };
            e[2] = new Emp { EmpId = 3, EmpName = "Prathyusha", EmpAddress = "Mysore", Dob = DateTime.Parse("12/4/1999") };
            e[3] = new Emp { EmpId = 4, EmpName = "Anusha", EmpAddress = "Mysore", Dob = DateTime.Parse("12/4/1999")};
            e[4] = new Emp { EmpId = 5, EmpName = "Aparna", EmpAddress = "Mysore", Dob = DateTime.Parse("12/4/1999") };
            foreach(var Emp in e)
            {
               Console.WriteLine($"{Emp.EmpId} \t {Emp.EmpName} \t {Emp.EmpAddress} \t {Emp.Dob.ToShortDateString()} ");
            }

        }
    }
}
