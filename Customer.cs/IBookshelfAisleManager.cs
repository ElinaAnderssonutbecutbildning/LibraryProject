using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IBookshelfAisleManager
    {
        public void AddBookshelfAisle(int BookshelfAisleNumber);
        

        void RemoveBookshelfAisle(int bookshelfAisleID);

        BookShelfAisle GetBookshelfAisleByBookshelfAisleNumber(int bookshelfAisleNumber);


    }
}
