using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IBookLoanManager
    {
        void CloseBookLoan(int bookLoanID);
        void AddLoan(int customerID, int bookID);
        bool IsBookLoaned(int bookID);
        BookLoan GetBookLoanByBookLoanID(int bookLoanID);
        public List<BookLoan> GetLoansByCustomerID(int customerID);
    }
}
