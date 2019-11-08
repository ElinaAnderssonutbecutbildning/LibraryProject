using DataAccess;
using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library1
{
    public class AisleAndShelfAPI
    {
        private IBookshelfAisleManager bookShelfAisleManager;
        private IShelfManager ShelfManager;
        private IBookManager bookManager;

        public AisleAndShelfAPI (IBookshelfAisleManager bookShelfAisleManager, IShelfManager shelfManager, IBookManager bookManager)
        {
            this.BookShelfAisleManager = bookShelfAisleManager;
            this.ShelfManager = shelfManager;
            this.bookManager = bookManager;
        }

        public IBookshelfAisleManager BookShelfAisleManager { get => bookShelfAisleManager; set => bookShelfAisleManager = value; }

        public bool AddBookShelfAisle(int bookShelfAisleNumber)
        {
            var existingbookShelfAisle = BookShelfAisleManager.GetBookshelfAisleByBookshelfAisleNumber(bookShelfAisleNumber);
            if (existingbookShelfAisle != null)
                return false;
            BookShelfAisleManager.AddBookshelfAisle(bookShelfAisleNumber);
            return true;
        }
        public RemoveBookShelfAisleError RemoveBookShelfAisle(int bookShelfAisleNumber)
        {
            var bookShelfAisle = BookShelfAisleManager.GetBookshelfAisleByBookshelfAisleNumber(bookShelfAisleNumber);
            if (bookShelfAisle == null)
                return RemoveBookShelfAisleError.NoSuchBookShelfAisle;
            if (bookShelfAisle.Shelf.Count > 0)
                return RemoveBookShelfAisleError.BookShelfAisleHasShelf;

            bookShelfAisleManager.RemoveBookshelfAisle(bookShelfAisle.BookshelfAisleID);

            return RemoveBookShelfAisleError.Ok;
        }
        public bool AddShelf(int shelfNumber)
        {
            ShelfManager.GetShelfByShelfNumber(shelfNumber);
            return true;
        }

        public MoveShelfError MoveShelf(int shelfNumber, int bookShelfAisleNumber)
        {
            var newBookShlefAisle = BookShelfAisleManager.GetBookshelfAisleByBookshelfAisleNumber(bookShelfAisleNumber);
            if (newBookShlefAisle == null)
                return MoveShelfError.NoSuchBookShelfAisle;

            var shelf = ShelfManager.GetShelfByShelfNumber(shelfNumber);
            if (shelf == null)
                return MoveShelfError.NoSuchShelf;
            if (shelf.BookshelfAisleNumber == bookShelfAisleNumber)
                return MoveShelfError.ShelfAlreadyAtThatBookShelfAisle;

            ShelfManager.MoveShelf(shelf.ShelfID, newBookShlefAisle.BookshelfAisleID);

            return MoveShelfError.Ok;
        }
        public RemoveShelfError RemoveShelf(int shelfID)
        {
            var shelf = ShelfManager.GetShelfByShelfNumber(shelfID);
            if (shelf == null)
                return RemoveShelfError.NoSuchShelf;
            if (shelf.Books.Count > 0)
                return RemoveShelfError.ShelfHasBook;

            ShelfManager.RemoveShelf(shelf.ShelfID);

            return RemoveShelfError.Ok;
        }



    }
}
