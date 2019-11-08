using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShelfManager : IShelfManager
    {

        public Shelf GetShelfByShelfNumber(int ShelfNumber)
        {
            using var context = new LibraryContext();
            return (from s in context.Shelfs
                    where s.ShelfNumber == ShelfNumber
                    select s)
                         .Include(s => s.BookshelfAisle)
                         .FirstOrDefault();
        }

        public void MoveShelf(int shelfID, int bookShelfAisleID)
        {
            using var context = new LibraryContext();
            var shelf = (from s in context.Shelfs
                         where s.ShelfID == shelfID
                         select s)
                         .First();
            shelf.BookshelfAisleID = bookShelfAisleID;
            context.SaveChanges();
        }
        public void RemoveShelf(int getShelfByShelfNumber)
        {
            using var context = new LibraryContext();
            var shelf = (from b in context.Shelfs
                        where b.GetShelfByShelfNumber == getShelfByShelfNumber
                        select b).FirstOrDefault();
            context.Shelfs.Remove(shelf);
            context.SaveChanges();
        }


        public void AddShelf(int ShelfNumber, int bookShelfAilseNumber)
        {
            using var context = new LibraryContext();
            var bookShelfIsleManager = new BookshelfAisleManager();
            var Shelf = new Shelf();
            Shelf.ShelfNumber = ShelfNumber;
            Shelf.BookshelfAisleID = bookShelfIsleManager.GetBookshelfAisleByBookshelfAisleNumber(bookShelfAilseNumber).BookshelfAisleID;
            context.Shelfs.Add(Shelf);
            context.SaveChanges();
        }
    }
   
}

