using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public enum MoveShelfError
    {
        Ok,
        NoSuchShelf,
        ShelfAlreadyAtThatBookShelfAisle,
        NoSuchBookShelfAisle
    }
}
