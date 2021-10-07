using System;
using SampleConApp.Day02;
namespace SampleConApp.Day04
{
    class Book
    {
        public int BookNum { get; set; }
        public string BookName { get; set; }
        public double version { get; set; }
        public string author { get; set; }

    }
    class BookDetails
    {
        static Book NewBook()
        {
            Console.WriteLine("Enter Book details ");
            var num = MyConsole.GetNumber("Enter book number");
            var name = MyConsole.GetString("Enter name of the book");
            var ver = MyConsole.GetDouble("Enter Version number of the book");
            var author = MyConsole.GetString("Enter author name of the book");
            Book bk = new Book
            {
                BookNum = num,
                BookName = name,
                author = author,
                version = ver
            };
            return bk;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of books you want to enter");
            int size = int.Parse(Console.ReadLine());
            Book[] bks = new Book[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the book {i}");
                bks[i] = NewBook();
            }
            foreach (var bk in bks)
            {
                Console.WriteLine($"The Book  Details are as follows\nThe book number is {bk.BookNum}\nThe Book name is {bk.BookName}\nThe book Version is {bk.version}\nThe author name is {bk.author}");

            }
        }
    }
}

