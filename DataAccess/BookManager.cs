using IDataInterface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess
{
    public class BookManager : IBookManager
    {
        public void AddBook(string BookName, int BookPrice)
        {
            using var context = new LibraryContext();
            var Book = new Book();
            Book.BookName = BookName;
            Book.BookPrice = BookPrice;
            context.Books.Add(Book);
            context.SaveChanges();
        }


        public Book GetBookByBookName(string BookName)
        {
            using var context = new LibraryContext();
            return (from b in context.Menu
                    where b.BookName == BookName
                    select b).FirstOrDefault();
        }

        public List<Book> GetMenu()
        {
            using var context = new LibraryContext();
            return (from b in context.Menu
                    select b).ToList();
        }

        internal Book GetBookByBookID(int bookID)
        {
            using var context = new LibraryContext();
            return (from b in context.Menu
                    where b.BookID == bookID
                    select b).FirstOrDefault();
        }

        public void MoveBook (int bookID, int shelfID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                        where b.BookID == bookID
                        select b).First();
            book.ShelfID = shelfID;
            context.SaveChanges();


        }

        public void RemoveBook(string bookName)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                        where b.BookName == bookName
                        select b).FirstOrDefault();
            context.Books.Remove(book);
            context.SaveChanges();
        }
       

    }
}
