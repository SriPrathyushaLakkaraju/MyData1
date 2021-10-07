using System;
namespace SampleConApp.Day05
{
    class Employee
    {
        public int EmpID { get; set; } = 123;
        public string EName { get; set; } = "Sri";
        public string EAddress { get; set; } = "Narasaraopet";
        public double EPhone { get; set; } = 9765467986;
    }
    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Console.WriteLine($"The Employee name is {emp.EName}");
            Employee temp = new Employee { EmpID = 123, EName = "Prathyusha", EAddress = "Narasaraopet", EPhone = 1234567 };
            Console.WriteLine($"The name of the employee is {temp.EName} Id is {temp.EmpID} from {temp.EAddress} and phone number is {temp.EPhone}");
        }
    }
}
