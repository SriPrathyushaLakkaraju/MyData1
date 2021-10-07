using System;
using SampleConApp.Day02;
namespace SampleConApp.Day05
{
    class Book
    { 
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public double BookPrice { get; set; }
    }
    class BookDemo
    {
       static Book NewBook()
        {
            var id = MyConsole.GetNumber("Enter book id");
            var title = MyConsole.GetString("Enter title of the book");
            var author = MyConsole.GetString("Enter author name");
            var price = MyConsole.GetDouble("Enter price of the book");
            Book bk = new Book { BookId = id, BookTitle = title, BookAuthor = author, BookPrice = price };
            return bk;
        }
        static void Main(string[] args)
        {
            //Book bk = new Book { BookId = 123, BookTitle = "C Language", BookAuthor = "Stephen", BookPrice = 560 };
            int size = MyConsole.GetNumber("Enter number of books you want to add");
            Book[] bks = new Book[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter book {i + 1} Details");
                bks[i] = NewBook();
            } 
            Console.WriteLine("The book are");
            foreach (var bk in bks)
            {
                //Console.WriteLine($"Tne Book id is {bk.BookId} book title is {bk.BookTitle} author name is {bk.BookAuthor} and the price of the book is {bk.BookPrice}");
                Console.Write($"{bk.BookTitle},");
            }
            Console.WriteLine("\n");
        }
    }
}
