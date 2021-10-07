using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleDB.Day20
{
   
    class LINQtoXMLDemo
    {
        static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            //firstDemo();
            //showEmployeesWithDept();
            //showEmployeesOfDept("Testing");
            //orderByFirstLetter();
            //insertRecord();
            //insertBulkRecords();
            //deleteRecord();
            updateRecord();
        }

        private static void updateRecord()
        {
            var empData = context.Employees.Where((e) => e.DeptId == 1).ToList();
            for (int i = 0; i < empData.Count; i++)
            {
                if (i % 3 == 0)
                    empData[i].DeptId = 2;
                else
                    empData[i].DeptId = 4;
            }
            context.SubmitChanges();
        }

        private static void insertBulkRecords()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var records = (from element in doc.Descendants("Employee")
                           select new Employee
                           {
                               DeptId = 1,
                               EmpAddress = element.Element("EmpCity").Value,
                               EmpSalary = int.Parse(element.Element("EmpSalary").Value),
                               EmpName = element.Element("EmpName").Value,
                           }).Take(20);
            context.Employees.InsertAllOnSubmit(records);
            context.SubmitChanges();
        }

        private static void deleteRecord()
        {
            Console.WriteLine("Enter Employee id to delete");
            var id = int.Parse(Console.ReadLine());
            //var rec = (from emp in context.Employees
            //           where emp.EmpID == id
            //         select emp).SingleOrDefault();
            var rec = context.Employees.FirstOrDefault((e) => e.EmpID == id);
            if (rec == null) Console.WriteLine("This rec does not exist");
            else
            {
                context.Employees.DeleteOnSubmit(rec);
                context.SubmitChanges();
                Console.WriteLine("Employee deleted");
            }
             
        }

        private static void insertRecord()
        {
            //create the employee object to add
            // var emp = new Employee { DeptId = 1, EmpName = "Aparna", EmpAddress = "Delhi", EmpSalary = 60000 };
            Console.WriteLine("Enter Employee Dept number 1,2 or 3");
            var deptiid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Employee Address");
            var addr = Console.ReadLine();
            Console.WriteLine("Enter Employee salary");
            var salary =int.Parse( Console.ReadLine());
            var emp = new Employee { DeptId = deptiid, EmpName = name, EmpAddress = addr, EmpSalary = salary };
            context.Employees.InsertOnSubmit(emp);//add the employee object to the employees collection of the context
            context.SubmitChanges();//commit the operation
        }

        private static void orderByFirstLetter()
        {
            var groups = from emp in context.Employees
                         group emp by emp.EmpName[0] into g
                         orderby g.Key
                         select g;
            foreach(var gr in groups)
            {
                Console.WriteLine("Employee Names starting with letter : "+gr.Key);
                foreach (var emp in gr)
                {
                    Console.WriteLine($"{emp.EmpName} from {emp.EmpAddress}");
                }
            }
        }

        private static void showEmployeesWithDept()
        {
            var result = from emp in context.Employees
                         select new
                         {
                             Name = emp.EmpName,
                             Dept = emp.Dept.DeptName
                         };
            foreach (var res in result) Console.WriteLine(res);
        }

        private static void showEmployeesOfDept(string deptName)
        {
            var result = (from dept in context.Depts
                          where dept.DeptName == deptName
                          select dept.Employees).FirstOrDefault();
            foreach (var cst in result)
            {
                Console.WriteLine(cst.EmpName);
            }
        }

        private static void firstDemo()
        {
            var data = from cst in context.Customers
                       where cst.City == "Bangalore"
                       orderby cst.CustomerName descending
                       select cst.CustomerName;
            foreach (var cst in data)
            {
                Console.WriteLine(cst);
            }
        }
    }
}
