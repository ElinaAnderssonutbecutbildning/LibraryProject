using System;
using IDataInterface;
using DataAccess;
namespace LibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerManager customerManager = new CustomerManager();
            customerManager.AddCustomer("Lars", "19930503" ,0);

            IBookshelfAisleManager BookshelfAisleManager1 = new BookshelfAisleManager();
            BookshelfAisleManager1.AddBookshelfAisle(1);

            IBookshelfAisleManager BookshelfAisleManager2 = new BookshelfAisleManager();
            BookshelfAisleManager2.AddBookshelfAisle(2);

            IBookshelfAisleManager BookshelfAisleManager3 = new BookshelfAisleManager();
            BookshelfAisleManager3.AddBookshelfAisle(3);

            IShelfManager shelfManager1 = new ShelfManager();
            shelfManager1.AddShelf(1,1);

            IShelfManager shelfManager2 = new ShelfManager();
            shelfManager2.AddShelf(2, 2);

            IShelfManager shelfManager3 = new ShelfManager();
            shelfManager3.AddShelf(3, 3);

            IBookManager bookManager1 = new BookManager();
            bookManager1.AddBook("Sagan om ringen", 199);

            IBookManager bookManager2 = new BookManager();
            bookManager2.AddBook("Clean Code", 159);

            IBookManager bookManager3 = new BookManager();
            bookManager3.AddBook("Harry Potter", 179);

            IBookManager bookManager4 = new BookManager();
            bookManager4.AddBook("Nalles stora blåa hus", 200);

            IBookManager bookManager5 = new BookManager();
            bookManager5.AddBook("Bamse", 99);
        } 
    }
}
