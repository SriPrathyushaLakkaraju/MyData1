using System;
using SampleConApp.Day02;
namespace SampleConApp.Day03
{
    class EmployeeUser
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public DateTime EmpDOB { get; set; }
    }

    class EmpDataUser
    {
        static EmployeeUser createEmployee()
        {
            var empid = MyConsole.GetNumber("Enter Employee id");
            var empname = MyConsole.GetString("Enter employee name");
            var empdob = MyConsole.GetDate("Enter date of birth");
            EmployeeUser emp = new EmployeeUser { EmpId = empid, EmpName = empname, EmpDOB = empdob };
            return emp;
        }
        static void Main(string[] args)
        {

            // EmployeeUser emp = createEmployee();
            //Console.WriteLine($"The employee id is {emp.EmpId}\nemp name is {emp.EmpName}\nemp date of birth is {emp.EmpDOB.ToShortDateString()} and age of the employee is {DateTime.Now.Year-emp.EmpDOB.Year}");
            Console.WriteLine("Enter number of employees");
            int size = int.Parse(Console.ReadLine());
            EmployeeUser[] employees = new EmployeeUser[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter Employee {i} ");
                employees[i] = createEmployee();
            }
            Console.WriteLine("The Employee Details are");
            foreach (var emp in employees)
            {
                Console.WriteLine($"The employee id is {emp.EmpId}\nemp name is {emp.EmpName}\nemp date of birth is {emp.EmpDOB.ToShortDateString()} and age of the employee is {DateTime.Now.Year - emp.EmpDOB.Year}");
            }
        }
    }
}
