using System;
using SampleConApp.Day02;
namespace SampleConApp.Day04
{
    class Students
    {
        public int SID { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        
    }
    class StudentClass
    {
        private const int cstSize = 10;
        private static Students[] _stus = new Students[cstSize];
        static string getMenu()
        {
            string menu = "-------------------CUSTOMER MANAGEMENT SOFTWARE--------------------\n";
            menu += "TO ADD STUDENT---------------->PRESS 1\n";
            menu += "TO DELETE STUDENT---------------->PRESS 2\n";
            menu += "TO UPDATE STUDENT---------------->PRESS 3\n";
            menu += "TO FIND STUDENT---------------->PRESS 4\n";
            return menu;
        }
        static void Main(string[] args)
        {
            bool tryAgain = true;
            do
            {
                string menu = getMenu();
                int choice = MyConsole.GetNumber(menu);
                tryAgain = processMenu(choice);
            } while (tryAgain);

        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                   EnterNewStudent();
                    Console.WriteLine("Customer added successfully");
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    FindStudent();
                    break;
                default:
                    return false;
            }
            return true;
        }
        private static void FindStudent()
        {
            string nameToFind = MyConsole.GetString("Enter the name or part of the name to search");
            foreach (var cst in _stus)
            {
                if (cst != null && cst.SName.Contains(nameToFind))
                {
                    Console.WriteLine($"The Name: {cst.SName} from {cst.SAddress}");
                }

            }
        }
        private static void UpdateStudent()
        {
            string nameToFind = MyConsole.GetString("Enter the name or part of the name to search");
            foreach (var cst in _stus)
            {
                if (cst != null && cst.SName.Contains(nameToFind))
                {
                    var name = MyConsole.GetString("Update the Name");
                    var id = MyConsole.GetNumber("Update the ID");
                    var add = MyConsole.GetString("Update the address");
                }
               
            }
            Console.WriteLine($"Customer with ID {nameToFind} does not exist");
        }
        private static void DeleteStudent()
        {
            int idToDelete = MyConsole.GetNumber("Enter the ID of the customer to delete");
            for (int i = 0; i < cstSize; i++)
            {
                if (_stus[i] != null && _stus[i].SID == idToDelete)
                {
                    _stus[i] = null;//We dont have delete in C#. U simply assign it to null
                    Console.WriteLine($"Customer with ID {idToDelete} has been deleted");
                    return;
                }
            }
            Console.WriteLine($"Customer with ID {idToDelete} does not exist");
        }
        private static void EnterNewStudent()
        {
            var name = MyConsole.GetString("Enter the Name");
            var address = MyConsole.GetString("Enter the Student Address");
            var id = MyConsole.GetNumber("Enter the ID");
           for (var i = 0; i < cstSize; i++)//find the first occurance of null in the array
            {
                if (_stus[i] == null)
                {
                    _stus[i] = new Students
                    {
                       SID=id,SName=name,SAddress=address
                    };
                    return;//exit the function...
                }
            }
        }

    }
}
