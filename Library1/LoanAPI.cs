using DataAccess;
using IDataInterface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace Library1
{
    public class LoanAPI
    {
        IBookManager bookManager;
        IBookLoanManager bookLoanManager;
        ICustomerManager customerManager;
        IShelfManager shelfManager;
        IMoneyDebtManager moneyDebtManager;

        public LoanAPI(IBookManager bookManager,
            IBookLoanManager bookLoanManager,
            IBookshelfAisleManager bookshelfAisleManager,
            ICustomerManager customerManager, IShelfManager shelfManager,
            IMoneyDebtManager moneyDebtManager)
        {
            this.bookManager = bookManager;
            this.bookLoanManager = bookLoanManager;
            this.customerManager = customerManager;
            this.shelfManager = shelfManager;
            this.moneyDebtManager = moneyDebtManager;
        }
        public List<Book> GetMenu()
        {
            return bookManager.GetMenu();
        }

        public BookLoanErrorCodes AddToBookLoan(string bookName, String customerName)
        {
            var book = bookManager.GetBookByBookName(bookName);
            if (book == null)
                return BookLoanErrorCodes.NoSuchBook;
            var customer = customerManager.GetCustomer(customerName);

            bookLoanManager.AddLoan(customer.CustomerID, book.BookID);
            return BookLoanErrorCodes.Ok;
        }
        public BookRemoveIt LoanBook(string bookName)
        {
            var book = bookManager.GetBookByBookName(bookName);
            if (book == null)
                return new BookRemoveIt { BookIsNotRemoveItStatus = BookRemoveIt.Status.NoSuchBook };
            var bookLoan = bookLoanManager.IsBookLoaned(book.BookID);
            if (bookLoan)
                return new BookRemoveIt { BookIsNotRemoveItStatus = BookRemoveIt.Status.BookAlreadyLoaned };
            var bookIsNotRemoveIt = new BookRemoveIt();

            bookIsNotRemoveIt.Amount += book.BookPrice;
            bookIsNotRemoveIt.BookIsNotRemoveItStatus = bookIsNotRemoveIt.Amount > 0 ? BookRemoveIt.Status.Open : BookRemoveIt.Status.BookAlreadyLoaned;
            return bookIsNotRemoveIt;
        }
        public bool AddBook(string bookName, int bookPrice)
        {
            var existingBook = bookManager.GetBookByBookName(bookName);
            if (existingBook != null)
                return false;
            bookManager.AddBook(bookName,bookPrice);
            return true;
        }
        public RemoveBookError RemoveBook(string bookName)
        {
            var newBook = bookManager.GetBookByBookName(bookName);
            if (newBook == null)
                return RemoveBookError.NoSuchBook;
            if (newBook.BookLoan != null || newBook.BookLoan.Any(l => l.IsActive))
                return RemoveBookError.BookIsLoaned;

            bookManager.RemoveBook(newBook.BookName);

            return RemoveBookError.Ok;

        }

       
        public MoveBookError MoveBook(string bookName, int shelfID)
        {
            var newbook = bookManager.GetBookByBookName(bookName);
            if (newbook == null)
                return MoveBookError.NoSuckBook;
            var newShelf = shelfManager.GetShelfByShelfNumber(shelfID);
            if (newShelf == null)
                return MoveBookError.NoSuckBook;
            bookManager.MoveBook(newbook.BookID, newShelf.ShelfID);
            return MoveBookError.Ok;
        }
        public bool BookBorrowedOrNot(string bookName, Book IsBookLoaned)
        {
            var ifBookIsBorrowed = bookManager.GetBookByBookName(bookName);
            if (ifBookIsBorrowed == IsBookLoaned)
                return false;
            bookManager.GetBookByBookName(bookName);
            return true;
        }
        public RemoveMoneyDebtError AddToMoneyDebt(int moneyDebtNumber, String customerName)
        {
            var addMoneyDebt = moneyDebtManager.GetMoneyDebtByMoneyDebtNumber(moneyDebtNumber);
            if (addMoneyDebt == null)
                return RemoveMoneyDebtError.NoSuchMoneyDebt;
            var customer = customerManager.GetCustomer(customerName);
            moneyDebtManager.GetActiveMoneyDebt(customer.CustomerID);
            return RemoveMoneyDebtError.Ok;
        }
        public RemoveMoneyDebtError AddMoneyDebt(string customersDateOfBirthYYYYMMDD, int moneyDebtNumber)
        {
            var customer = customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            if (customer == null)
                return RemoveMoneyDebtError.NoSuchCustomer;
            var moneyDebt = moneyDebtManager.GetMoneyDebtByMoneyDebtNumber(moneyDebtNumber);
            if (moneyDebt == null)
                return RemoveMoneyDebtError.NoOpenMoneyDebt;
            var moneyDebt2 = moneyDebtManager.GetActiveMoneyDebt(customer.CustomerID);
            if (moneyDebt2 == null)
                moneyDebt2 = moneyDebtManager.CreateActiveMoneyDebt(customer.CustomerID);
            moneyDebtManager.UpdateMoneyDebt(moneyDebt2.MoneyDebtID, moneyDebtNumber);
            return RemoveMoneyDebtError.Ok;
        }
        public RemoveMoneyDebtError RemoveMoneyDebt(int moneyDebtNumber)
        {
            var newMoneyDebt = moneyDebtManager.GetMoneyDebtByMoneyDebtNumber(moneyDebtNumber);
            if (newMoneyDebt == null)
                return RemoveMoneyDebtError.NoSuchMoneyDebt;
            if (newMoneyDebt.GetActiveMoneyDebt > 0)
                return RemoveMoneyDebtError.CustomerHasMoneyDebt;


            return RemoveMoneyDebtError.Ok;

        }

        public bool AddCustomer(string customersDateOfBirthYYYYMMDD)
        {
            var customer = customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            if (customer == null)
                return false;

            customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            return true;
        }
        public RemoveCustomerError RemoveCustomer(string customersDateOfBirthYYYYMMDD)
        {
            var newCustomer = customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            if (newCustomer == null)
                return RemoveCustomerError.NoSuchCustomer;
            if (newCustomer.BookLoans != null)
                return RemoveCustomerError.CustomerHasBook;

            return RemoveCustomerError.Ok;

        }
        public bool IfCustomerHasBookLoanOrMoneyDebt(string customersDateOfBirthYYYYMMDD)
        {
            var ifCustomerHasBookLoanOrPayCheck = customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            if (ifCustomerHasBookLoanOrPayCheck.MoneyDebt.Any(m => m.IsActive) ||
                bookLoanManager.GetLoansByCustomerID(ifCustomerHasBookLoanOrPayCheck.CustomerID).Count > 0)
                return false;
            customerManager.GetCustomer(customersDateOfBirthYYYYMMDD);
            return false;
        }
    }
}
