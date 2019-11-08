using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IShelfManager
    {
       public void AddShelf(int ShelfNumber, int bookShelfAilseNumber);
        void MoveShelf(int shelfID, int bookShelfAsileID);
        Shelf GetShelfByShelfNumber(int shelfNumber);
        void RemoveShelf(int shelfNumber);
    }
}
