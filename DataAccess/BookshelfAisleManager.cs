using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace DataAccess
{
    public class BookshelfAisleManager : IBookshelfAisleManager
    {
        public void AddBookshelfAisle(int BookshelfAisleNumber)
        {
            using var context = new LibraryContext();
            var BookshelfAisle = new BookShelfAisle();
            BookshelfAisle.BookshelfAisleNumber = BookshelfAisleNumber;
            context.BookShelfAisles.Add(BookshelfAisle);
            context.SaveChanges();
        }

        public BookShelfAisle GetBookshelfAisleByBookshelfAisleNumber(int booksheltAisleNumber)
        {
            using var context = new LibraryContext();
            return (from b in context.BookShelfAisles
                    where b.BookshelfAisleNumber == booksheltAisleNumber
                    select b)
                    .Include( b=> b.Shelf)
                    .FirstOrDefault();

        }

        public void RemoveBookshelfAisle(int BookshelfAisleID)
        {
            using var context = new LibraryContext();
            var bookshelfAisle = (from b in context.BookShelfAisles
                                  where b.BookshelfAisleID == BookshelfAisleID
                                  select b).FirstOrDefault();
            context.BookShelfAisles.Remove(bookshelfAisle);
            context.SaveChanges();
        }
    }
}
