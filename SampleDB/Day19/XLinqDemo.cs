using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SampleDB.Day19
{
    class XLinqDemo
    {
        static void Main(string[] args)
        {
            // convertListToXml();
            //displayNamesFromXmlFile();
            //displayNamesandSalaryFromFile();
           // insertEmployeeToXml();
           // insertEmployeeToXmlById();
            deleteEmployeeInXmlById();
        }

        private static void deleteEmployeeInXmlById()
        {
            Console.WriteLine("Enter id to delete");
            string id = Console.ReadLine();
            XDocument doc = XDocument.Load("Employees.xml");
            var foundElement = (from element in doc.Descendants("Employee")
                                   where element.Element("EmpID").Value == id
                                   select element).SingleOrDefault();
            foundElement.Remove();//Delete the element
            doc.Save("Employees.xml");
        }

        private static void insertEmployeeToXmlById()
        {
            string id = Console.ReadLine();
            XDocument doc = XDocument.Load("Employees.xml");
            var selectedElement = (from element in doc.Descendants("Employee")
                                   where element.Element("EmpID").Value == id
                                   select element).FirstOrDefault();
            if(selectedElement==null)
            {
                Console.WriteLine("No element found");
            }
            else
            {
                var newelement = new XElement("Employee",
                      new XElement("EmpID", 502),
                      new XElement("EmpName", "Rahul"),
                      new XElement("EmpCity", "Bangalore"),
                      new XElement("EmpSalary", 75000)
                       );
                selectedElement.AddAfterSelf(newelement);
                doc.Save("Employees.xml");
            }
        }

        private static void insertEmployeeToXml()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            //where to insert : At last
            var last = doc.Descendants("Employee").Last();
            //data to insert
            var element = new XElement("Employee",
                       new XElement("EmpID", 501),
                       new XElement("EmpName", "Sachin"),
                       new XElement("EmpCity", "Bangalore"),
                       new XElement("EmpSalary", 65000)
                        );
            //insert the record
            last.AddAfterSelf(element);
            //save the file
            doc.Save("Employees.xml");
        }

        private static void displayNamesandSalaryFromFile()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var elements = from element in doc.Descendants("Employee")
                           select new
                           {
                               Name = element.Element("EmpName").Value,
                               Salary = element.Element("EmpSalary").Value
                           };
            foreach (var element in elements)
            {
                //Console.WriteLine(element);
                Console.WriteLine($"{element.Name} with salary {element.Salary}");
            }
        }

        private static void displayNamesFromXmlFile()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var elements = from element in doc.Descendants("Employee")
                          select element.Element("EmpName");
            foreach (var element in elements)
            {
                Console.WriteLine(element.Value);
            }
        }

        //Example to convert List<Employee> to Xml data using XLINQ
        private static void convertListToXml()
        {
            var data = FileData.GetAllEmployees();//List of Employee objects
            var root = new XElement("ListOfEmployees", from emp in data
                                                       select new XElement("Employee",
                                                       new XElement("EmpID", emp.EmpID),
                                                       new XElement("EmpName", emp.EmpName),
                                                       new XElement("EmpCity", emp.EmpCity),
                                                       new XElement("EmpSalary", emp.EmpSalary)
                                                       ));
            //Console.WriteLine(root);
            root.Save("Employees.xml");
        }
    }
}
