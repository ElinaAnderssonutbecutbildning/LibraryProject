using IDataInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Library1;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace UnitTests
{
    [TestClass]
    public class BooksTestAPI
    {
        [TestMethod]
        public void TestOkAddBook()
        {
            var BookManagerMock = new Mock<IBookManager>();
            var bookManagerMock = new Mock<IBookManager>(); 
            var BookLoanManagerMock = new Mock<IBookLoanManager>();
            var bookLoanManagerMock = new Mock<IBookLoanManager>();
            var BookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var CustomerManagerMock = new Mock<ICustomerManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var ShelfManagerMock = new Mock<IShelfManager>();
            var shelfManagerMock = new Mock<IShelfManager>();
            var MoneyDebtManagerMock = new Mock<IMoneyDebtManager>();
            var moneyDebtManagerMock = new Mock<IMoneyDebtManager>();

            Mock<IBookManager> bookNameMock = SetUpMock(
                new Book()
                );
            bool successfull = GetBookByBookName(bookManagerMock);
            Assert.IsTrue(successfull);
            bookManagerMock.Verify(
                m => m.AddBook(It.IsAny<string>(), It.IsAny<int>()));
            Times.Once();
        }
        [TestMethod]
        public void MoveBookOk()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            shelfManagerMock.Setup(m =>
               m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf { ShelfID = 2 });

            bookManagerMock.Setup(m =>
              m.GetBookByBookName(It.IsAny<string>()))
               .Returns(new Book
               {
                   BookName = "Boken",
                   Shelf = new Shelf()
               });

            var loanAPI = new LoanAPI(bookManagerMock.Object, null,
                null, null, shelfManagerMock.Object, null);
            var result = loanAPI.MoveBook("Bok", 1);
            Assert.AreEqual(MoveBookError.Ok, result);
            bookManagerMock.Verify(m =>
                m.MoveBook(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestExistingBook()
        {
            var bookManagerMock = new Mock<IBookManager>();

            var loanAPI = SetUpMock(new Book());
            var bookLoanManagerMock = new Mock<IBookLoanManager>();
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var shelfManagerMock = new Mock<IShelfManager>();
            var moneyDebtManagerMock = new Mock<IMoneyDebtManager>();

            var LoanAPI = new LoanAPI(bookManagerMock.Object, bookLoanManagerMock.Object,
                bookShelfAisleManagerMock.Object, customerManagerMock.Object, 
                shelfManagerMock.Object,moneyDebtManagerMock.Object);
            var successfull = LoanAPI.RemoveBook("Boken");
            Assert.AreEqual(RemoveBookError.NoSuchBook, successfull);
            bookManagerMock.Verify(
                m => m.RemoveBook(It.IsAny<string>()),
                    Times.Never());
        }
        private static Mock<IBookManager> SetUpMock(Book book)
        {
            var UniTestsMock2 = new Mock<IBookManager>();

            UniTestsMock2.Setup(m =>
                    m.GetBookByBookName(It.IsAny<string>()))
                .Returns(book);

            UniTestsMock2.Setup(m =>
                m.AddBook(It.IsAny<string>(),It.IsAny<int>()));
            return UniTestsMock2;
        }
        private static Mock<IBookLoanManager> SetUpMock(BookLoan bookLoan)
        {
            var UniTestsMock = new Mock<IBookLoanManager>();

            UniTestsMock.Setup(m =>
                    m.GetBookLoanByBookLoanID(It.IsAny<int>()))
                .Returns(bookLoan);

            UniTestsMock.Setup(m =>
                m.GetBookLoanByBookLoanID(It.IsAny<int>()));
            return UniTestsMock;
        }
        private static Mock<IBookshelfAisleManager> SetUpMock(BookShelfAisle bookshelfAisle)
        {
            var UniTestsMock = new Mock<IBookshelfAisleManager>();

            UniTestsMock.Setup(m =>
                    m.GetBookshelfAisleByBookshelfAisleNumber(It.IsAny<int>()))
                .Returns(bookshelfAisle);

            UniTestsMock.Setup(m =>
                m.AddBookshelfAisle(It.IsAny<int>()));
            return UniTestsMock;
        }
        private static Mock<ICustomerManager> SetUpMock(Customer customer)
        {
            var UniTestsMock = new Mock<ICustomerManager>();

            UniTestsMock.Setup(m =>
                    m.GetCustomer(It.IsAny<string>()))
                .Returns(customer);

            UniTestsMock.Setup(m =>
                m.GetCustomer(It.IsAny<string>()));
            return UniTestsMock;
        }
        private static Mock<IShelfManager> SetUpMock(Shelf shelf)
        {
            var UniTestsMock = new Mock<IShelfManager>();

            UniTestsMock.Setup(m =>
                    m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(shelf);

            UniTestsMock.Setup(m =>
                m.GetShelfByShelfNumber(It.IsAny<int>()));
            return UniTestsMock;
        }
        private static Mock<IMoneyDebtManager> SetUpMock(MoneyDebt moneyDebt)
        {
            var UniTestsMock = new Mock<IMoneyDebtManager>();

            UniTestsMock.Setup(m =>
                    m.GetMoneyDebtByMoneyDebtNumber(It.IsAny<int>()))
                .Returns(moneyDebt);

            UniTestsMock.Setup(m =>
                m.GetMoneyDebtByMoneyDebtNumber(It.IsAny<int>()));
            return UniTestsMock;
        }
        private static bool GetBookByBookName(Mock<IBookManager> bookManagerMock)
        {
            
            var bookLoanManagerMock = new Mock<IBookLoanManager>();
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var shelfManagerMock = new Mock<IShelfManager>();
            var moneyDebtManagerMock = new Mock<IMoneyDebtManager>();

            var LoanAPI = new LoanAPI(bookManagerMock.Object, bookLoanManagerMock.Object,
                bookShelfAisleManagerMock.Object, customerManagerMock.Object, 
                shelfManagerMock.Object,moneyDebtManagerMock.Object);
            var successfull = LoanAPI.AddBook("Boken",0);
            return successfull;
        }
    }

}