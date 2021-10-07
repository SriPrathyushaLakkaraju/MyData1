using System;
namespace SampleConApp.Day03
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress{ get; set; }
        public DateTime EmpDOB { get; set; }

    }
    class Employeeclass
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { EmpID = 123, EmpName = "sri", EmpAddress = "nrt", EmpDOB = DateTime.Parse("12/4/1999") };
            Console.WriteLine("The Employee Details are ");
            Console.WriteLine($"Employee ID is {emp.EmpID}");
            Console.WriteLine($"Employee name {emp.EmpName}");
            Console.WriteLine($"Employee address {emp.EmpAddress}");
            Console.WriteLine($"Employee dob {emp.EmpDOB.ToShortDateString()}");
            
        }
    }
}