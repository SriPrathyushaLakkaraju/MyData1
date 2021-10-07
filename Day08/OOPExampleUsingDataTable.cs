using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleConApp.Day06;
namespace SampleConApp.Day08
{
    class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
    interface IBookStore//plan where u dont need to worry about its implementation currently
    {
        void AddBook(Book book);
        void DeleteBook(int bookid);
        void UpdateBook(Book book);
        Book [] FindBook(string name);
    }
   
   

    class BookStore : IBookStore
    {
        private DataTable table = new DataTable();
        public BookStore()
        {
            table.Columns.Add("BookId", typeof(int));
            table.Columns.Add("BookTitle", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("Price", typeof(double));
        }
        public void AddBook(Book book)
        {
            DataRow row = table.NewRow();
            row[0] = book.BookId;
            row[1] = book.BookTitle;
            row[2] = book.Author;
            row[3] = book.Price;
            table.Rows.Add(row);
            table.AcceptChanges();
        }

        public void DeleteBook(int bookid)
        {
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row[0])==bookid)
                {
                    row.Delete();
                    return;
                }
            }
            throw new NoDataFoundException("No data found to delete.");
        }

        public Book [] FindBook(string name)
        {
                DataTable copy = table.Copy();//copies the schema and the data
                foreach (DataRow row in copy.Rows)
                {
                    if (!row[1].ToString().Contains(name))
                    {
                        row.Delete();//remove those rows that U dont want
                    }
                }
                Book[] array = new Book[copy.Rows.Count];
                int index = 0;
            foreach (DataRow row in copy.Rows)
            {
                var author = new Book
                {
                    BookId = Convert.ToInt32(row[0]),
                    BookTitle = row[1].ToString(),
                    Author = row[2].ToString(),
                    Price = Convert.ToDouble(row[3])
                };
                array[index] = author;
                index++;
            }
                return array;
            //return copy;//return table with valid rows...
            // DataTable copy = table.Copy();
            // foreach (DataRow row in copy.Rows)
            // {
            //  if(!row[0].ToString().Contains(name))
            // {
            //       row.Delete();
            // }
            // }
            // return copy;
            //return copy == null ? throw new NoDataFoundException("No data found") : copy;
        }

        public void UpdateBook(Book book)
        {
            foreach (DataRow row in table.Rows)
            {
                if(Convert.ToInt32(row[0])==book.BookId)
                {
                    row[1] = book.Price;
                    table.AcceptChanges();
                    return;
                }
            }
            throw new NoDataFoundException("No book found to update.");
        }
    }



    [Serializable]
    public class NoDataFoundException : ApplicationException
    {
        public NoDataFoundException() { }
        public NoDataFoundException(string message) : base(message) { }
        public NoDataFoundException(string message, Exception inner) : base(message, inner) { }
        protected NoDataFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class OOPExampleUsingDataTable
    {
        const string menu = "----------BOOK STORE--------------------\nTO ADD BOOK--------->PRESS 1\nTO DELETE BOOK------------->PRESS 2\nTO UPDATE BOOK-------->PRESS 3\nTO FIND BOOK DETAILS---->PRESS 4\n";
        static IBookStore bs = new BookStore();
        static void Main()
        {
            bool processing = true;
            do
            {
                var choice = MyConsoleNew.GetNumber(menu);
                processing = ProcessMenu(choice);
            } while (processing);
        }
        private static bool ProcessMenu(uint choice)
        {
            switch (choice)
            {
                case 1:
                    AddBookDetails();
                    return true;
                case 2:

                    DeleteBook();
                    return true;
                case 3:
                    UpdateBook();
                    return true;
                case 4:
                    findingBook();
                    return true;
            }
            return false;//default value
        }

        private static void findingBook()
        {
            var name = MyConsoleNew.GetString("Enter book name to search");
            try
            {
                bs.FindBook(name);
                
            }
            catch(NoDataFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateBook()
        {
            var id = (int)MyConsoleNew.GetNumber("Enter Book Id");
          //  var name = MyConsoleNew.GetString("Enter book title");
            //var author = MyConsoleNew.GetString("Enter Author name");
            var price = MyConsoleNew.GetDouble("Enter Price of the book to update");
            Book bc = new Book { BookId = id ,Price=price};

            try
            {
                bs.UpdateBook(bc);
                Console.WriteLine($"Book price is updated.");
            }
            catch (NoDataFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteBook()
        {
  
            int bookid = (int)MyConsoleNew.GetNumber("Enter id to delete the book");
            try
            {
                bs.DeleteBook(bookid);
                Console.WriteLine($"The data for bookid {bookid} deleted successfully.");
            }
            catch(NoDataFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddBookDetails()
        {
            var id =(int) MyConsoleNew.GetNumber("Enter Book Id");
            var name = MyConsoleNew.GetString("Enter book title");
            var author = MyConsoleNew.GetString("Enter Author name");
            var price = MyConsoleNew.GetDouble("Enter Price of the book");
            Book bc = new Book { BookId = id,BookTitle = name, Author = author, Price = price };
            bs.AddBook(bc);
            Console.WriteLine("The book details added successfully.");
        }
       
    }
}
