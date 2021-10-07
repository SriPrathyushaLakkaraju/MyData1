using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDB.Day19
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
    }
    static class FileData
    {
        const string filename = @"../../Day19/EmpData.csv";
        public static List<Employee> GetAllEmployees()
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("Datasource not found");
            var list = new List<Employee>();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var words = line.Split(',');
                var emp = new Employee
                {
                    EmpID = int.Parse(words[0]),
                    EmpName = words[1],
                    EmpCity = words[2],
                    EmpSalary = int.Parse(words[3])
                };
                list.Add(emp);
            }
            return list;
        }
    }
    class LinqDemo
    {
        static List<Employee> theList = FileData.GetAllEmployees();
        static void Main(string[] args)
        {
            //readOnlyNames();
            //readNamesWithCity();
            //whereClauseExample();
            // orderbyClause();
            groupByClause();
        }

        private static void groupByClause()
        {
            var groups = from emp in theList
                         group emp.EmpName by emp.EmpCity into gr
                         orderby gr.Key
                         select gr;
            //nested loop iterate through the groups and in each group another iteration
            foreach (var gr in groups)
            {
                Console.WriteLine("The City : "+gr.Key);
                foreach (var name in gr)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("------------------------------------------------------------");
            }
        }

        private static void orderbyClause()
        {
            var data = from emp in theList
                       orderby emp.EmpCity descending
                       select emp.EmpCity;
            foreach (var item in data.Distinct())//Display only distinct cities
            {
                Console.WriteLine(item);
            }
        }

        private static void whereClauseExample()
        {
            var data = from emp in theList
                       where emp.EmpCity == "Narasaraopet" && emp.EmpName.StartsWith("S")
                       select emp.EmpName;
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }

        private static void readNamesWithCity()
        {
            var names = from emp in theList select new { emp.EmpName, emp.EmpCity };
            foreach (var item in names)
            {
                Console.WriteLine($"{item.EmpName} from {item.EmpCity}");
            }
        }

        private static void readOnlyNames()
        {
            var names = from emp in theList 
                        select emp.EmpName;//select empname from thelist
            //LINQ query will always result a IEnumerable object which when iterated,will read the data.
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
