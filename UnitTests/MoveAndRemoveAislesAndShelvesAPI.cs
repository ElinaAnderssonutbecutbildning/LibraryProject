using IDataInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Library1;
using System;

namespace UnitTests
{
    [TestClass]
    public class UniTests
    {
        [TestMethod]
        public void AddTestBookShelfAisle()
        {
            var BookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();

            Mock<IBookshelfAisleManager> bookshelfAisleNumberMock = SetUpMock(null);
            bool successfull = AddBookShelfAisleNumberOne(bookShelfAisleManagerMock);
            Assert.IsTrue(successfull);
            bookShelfAisleManagerMock.Verify(
                m => m.AddBookshelfAisle(It.Is<int>(i => i == 1)),
                    Times.Once());

        }
        [TestMethod]
        public void TestAddExistingBookShelfAisle()
        {
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();

            var aisleAndShelfAPI = SetUpMock(new BookShelfAisle());
            bool successfull = AddBookShelfAisleNumberOne(aisleAndShelfAPI);
            Assert.IsFalse(successfull);
            bookShelfAisleManagerMock.Verify(
                m => m.AddBookshelfAisle(It.Is<int>(i => i == 1)),
                    Times.Never());
        }
        public void RemoveEmptyBookShelfAisle()
        {
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var BookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            bookShelfAisleManagerMock.Setup(m =>
               m.GetBookshelfAisleByBookshelfAisleNumber(It.IsAny<int>()))
                .Returns(new BookShelfAisle
                {
                    BookshelfAisleNumber = 3,
                    Shelf = new List<Shelf>()
                });

            var asileAndShelfAPI = new AisleAndShelfAPI(
                bookShelfAisleManagerMock.Object, shelfManagerMock.Object, null);
            var successfull = asileAndShelfAPI.RemoveBookShelfAisle(3);
            Assert.AreEqual(RemoveBookShelfAisleError.Ok, successfull);
            bookShelfAisleManagerMock.Verify(m =>
                m.RemoveBookshelfAisle(It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void RemoveBookShelfAisleWithOneShelf()
        {
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            bookShelfAisleManagerMock.Setup(m =>
               m.GetBookshelfAisleByBookshelfAisleNumber(It.IsAny<int>()))
                .Returns(new BookShelfAisle
                {
                   BookshelfAisleNumber = 4,
                   Shelf = new List<Shelf> 
                   {
                        new Shelf()
                   }
                });

            var aisleAndShelfAPI = new AisleAndShelfAPI(
                bookShelfAisleManagerMock.Object, shelfManagerMock.Object, null);
            var successfull = aisleAndShelfAPI.RemoveBookShelfAisle(4);
            Assert.AreEqual(RemoveBookShelfAisleError.BookShelfAisleHasShelf, successfull);
            bookShelfAisleManagerMock.Verify(m =>
               m.RemoveBookshelfAisle(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void RemoveNonexistingBookShelfAisle()
        {
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            bookShelfAisleManagerMock.Setup(m =>
               m.GetBookshelfAisleByBookshelfAisleNumber(It.IsAny<int>()))
                .Returns((BookShelfAisle)null);

            var aisleAndShelfAPI = new AisleAndShelfAPI(bookShelfAisleManagerMock.Object, 
                shelfManagerMock.Object, null);
            var successfull = aisleAndShelfAPI.RemoveBookShelfAisle(3);
            Assert.AreEqual(RemoveBookShelfAisleError.NoSuchBookShelfAisle, successfull);
            bookShelfAisleManagerMock.Verify(m =>
               m.RemoveBookshelfAisle(It.IsAny<int>()), Times.Never);
        }

        [TestMethod]
        public void MoveShelfOk()
        {
            var bookShelfAisleManagerMock = new Mock<IBookshelfAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            bookShelfAisleManagerMock.Setup(m =>
               m.GetBookshelfAisleByBookshelfAisleNumber(It.IsAny<int>()))
                .Returns(new BookShelfAisle { BookshelfAisleID = 2 });

            shelfManagerMock.Setup(m =>
              m.GetShelfByShelfNumber(It.IsAny<int>()))
               .Returns(new Shelf
               {
                   ShelfID = 2,
                   BookshelfAisle = new BookShelfAisle()
               });

            var aisleAndShelfAPI = new AisleAndShelfAPI(
                bookShelfAisleManagerMock.Object, shelfManagerMock.Object, null);
            var result = aisleAndShelfAPI.MoveShelf(1, 1);
            Assert.AreEqual(MoveShelfError.Ok, result);
            shelfManagerMock.Verify(m =>
                m.MoveShelf(2, 2), Times.Once());
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
        private static bool AddBookShelfAisleNumberOne(Mock<IBookshelfAisleManager> bookShelfAisleManagerMock)
        {
            var AisleAndShelfAPI = new AisleAndShelfAPI(
                bookShelfAisleManagerMock.Object, null, null);
            var successfull = AisleAndShelfAPI.AddBookShelfAisle(1);
            return successfull;
        }
    }
}
