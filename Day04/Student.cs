using System;
using SampleConApp.Day02;
namespace SampleConApp.Day04
{
    class Student
    {
        public int StuId { get; set; }
        public string Sname { get; set; }
        public DateTime Sdob { get; set; }
        public string SCol { get; set; }
    }
    class StudentDetails
    {
        static Student NewStudent()
        {
            Console.WriteLine("Enter student Details");
            var id = MyConsole.GetNumber("Enter student id");
            var name = MyConsole.GetString("Enter student name");
            var dob = MyConsole.GetDate("Enter date of birth of student in mm/dd/yyyy format");
            var col = MyConsole.GetString("Enter college name of the student");
            Student st = new Student { StuId = id, Sname = name, Sdob = dob, SCol = col };
            return st;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the Number of students you want to add");
            int size = MyConsole.GetNumber("Enter the number of students you want to add");
            Student[] std = new Student[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the {i} Details");
                std[i] = NewStudent();
            }
            foreach (var st in std)
            {

                Console.WriteLine($"The details of the students you entered as follows\nThe Student id is {st.StuId}\nThe student name is {st.Sname}\nThe Student date of birth is {st.Sdob.ToLongDateString()}\nThe college of the student is {st.SCol}");
            }
        }
    }
}
