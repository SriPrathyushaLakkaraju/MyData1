using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day02
{
    class empobject
    {
        static void Main(string[] args)
        {
            //Type Initializer in C# 4.0
            Employee emp = new Employee { EmpID = 1, EmpAddress = "Bangalore", EmpName = "Sri" };//creating object in C#....

            Console.WriteLine(emp.EmpID);//get
            Console.WriteLine(emp.EmpName);//get
            Console.WriteLine(emp.EmpAddress);//get
        }
    }
}