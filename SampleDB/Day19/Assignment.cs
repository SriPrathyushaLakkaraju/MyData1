using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleDB.Day19
{
    class Assignment
    {
        class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
            public string EmpCity { get; set; }
            public int EmpSalary { get; set; }
        }
        static void Main(string[] args)
        {
            convertXmlDataToList();
        }

        private static void convertXmlDataToList()
        {
            List<Employee> employees = new List<Employee>();
            XDocument doc = XDocument.Load("Employees.xml");
            var list= doc.Descendants("Employee");
            
        }
    }
}
