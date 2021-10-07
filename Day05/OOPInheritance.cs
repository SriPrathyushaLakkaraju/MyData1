using System;
namespace SampleConApp.Day05
{
    class Person
    {
        public string Name { get; set; }
    }
    class Student : Person
    {
        public int Class { get; set; }
    }
    class OOPInheritance
    {
        static void Main(string[] args)
        {
            Student st = new Student { Name = "Sri", Class = 10 };
            Console.WriteLine("Name of the student is {0}",st.Name);
            Console.WriteLine("The student studying {0} class",st.Class);
        }
    }
}
