using System;
using SampleConApp.Day06;
using SampleConApp.Day02;
namespace SampleConApp.Day07
{
    /*
   * Create an interface called IBookStore: Add, Delete, Find and Update functions to perform the operations.
   * Create a class that represents a book: ID, Title, Author, Price as properties.
   * Create a class that implements this interface and the internal data structure will be Book array.
   * Create a UI Component that will have functions to perform all the operations using a menu driven program.
    */
    interface IBookStore
    {
        void AddFunc(Book bc);
        void DeleteFunc(int id);
        void UpdateFunc(uint id,uint newid);
        void FindFunc();
    }
    class Book
    {
        public override string ToString()
        {
            return $"Book Id is :{BookId}\nThe Name of the book is:{Title}\nThe Price of the book is:{Price}\n";
        }
        public uint BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
    
    class BookStore : IBookStore
    {

        //Book bc = null;
        const byte size = 10;
        Book[] books = new Book[size];//limitation of Arrays, we are fixing the size.
        public void AddFunc(Book bc)
        {

            for (int i = 0; i < size; i++)
            {
                if (books[i] == null)
                {
                    books[i] = bc;
                    return;
                }
                else continue;
            }
            throw new AccountCreationFailedException("No more rows could be created");
        }

        public void DeleteFunc(int id)
        {
            for (int i = 0; i < size; i++)
            {
                if ((books[i] != null) && (books[i].BookId == id))
                {
                    books[i] = null;
                    return;
                }
            }
            throw new AccountNotFoundException($"Book with {id} not found to delete");
        }
        public void UpdateFunc(uint id,uint newprice)
        {
            for (int i = 0; i < size; i++)
            {
                if ((books[i] != null) && (books[i].BookId == id))
                {
                    books[i].Price =newprice;
                    return;
                }
            }
            throw new NameNotFoundException("Id not found to update");

        }

        public Book[] FindFunc()
        {
            return books;
        }

        void IBookStore.FindFunc()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class AccountCreationFailedException : ApplicationException
    {
        public AccountCreationFailedException() { }
        public AccountCreationFailedException(string message) : base(message) { }
        public AccountCreationFailedException(string message, Exception inner) : base(message, inner) { }
        protected AccountCreationFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class NameNotFoundException : ApplicationException
    {
        public NameNotFoundException() { }
        public NameNotFoundException(string message) : base(message) { }
        public NameNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected NameNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
        class OOPAssignment
        {
            const string menu = "----------BOOK STORE--------------------\nTO ADD BOOK--------->PRESS 1\nTO DELETE BOOK------------->PRESS 2\nTO UPDATE BOOK-------->PRESS 3\nTO FIND BOOK DETAILS---->PRESS 4\n";
            static BookStore bs = new BookStore();
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

                        DeleteAccount();
                        return true;
                    case 3:
                        UpdateAccount();
                        return true;
                    case 4:
                        findingAccountFunc();
                        return true;
                }
                return false;//default value
            }

            private static void findingAccountFunc()
            {

                var records = bs.FindFunc();
                var name = MyConsoleNew.GetString("Enter the name or partial name of the book to find");
                foreach (var bc in records)
                {
                    if (bc != null && bc.Title.Contains(name))
                    {

                        Console.WriteLine(bc);
                    return;
                    }
                }
            Console.WriteLine($"The given {name} not found in the array.");
            }

        private static void UpdateAccount()
        {
            var id= (uint)MyConsoleNew.GetNumber("Enter book id to check in the array");
            var newprice= (uint)MyConsoleNew.GetNumber("Enter new price for book id to update");
            try
            {
                bs.UpdateFunc(id,newprice);
                Console.WriteLine($"Book price for the book with ID {id} is updated in the array.");
            }
            catch (NameNotFoundException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

            private static void DeleteAccount()
            {

                var id = (int)MyConsoleNew.GetNumber("Enter book id to delete");
                try
                {
                    bs.DeleteFunc(id);
                    Console.WriteLine($"The book with {id} is deleted");
                }
                catch (AccountNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void AddBookDetails()
            {
                var id = MyConsoleNew.GetNumber("Enter Book Id");
                var name = MyConsoleNew.GetString("Enter book title");
                var author = MyConsoleNew.GetString("Enter Author name");
                var price = MyConsoleNew.GetDouble("Enter Price of the book");
                Book bc = new Book { BookId = (uint)id, Title = name, Author = author, Price = price };
            try
            {
                bs.AddFunc(bc);
                Console.WriteLine($"Book details added successfully.");
            }
            catch (AccountCreationFailedException ex)
            {

                Console.WriteLine(ex.Message);
            }
            }
        }
}

       
    

