using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IDataInterface
{
    public interface IBookManager
    {
        public void AddBook(string BookName, int bookPrice);
        List<Book> GetMenu();
        Book GetBookByBookName(string BookName);
        void RemoveBook(string bookName);
        void MoveBook(int bookID, int shelfID);
       
    }


}
