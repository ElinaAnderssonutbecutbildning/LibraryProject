using IDataInterface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace DataAccess
{
    public class BookLoanManager : IBookLoanManager
    {
        public void AddLoan(int customerID, int bookID)
        {
            using var context = new LibraryContext();
            var bookLoan = new BookLoan();
            bookLoan.BookID = bookID;
            bookLoan.CustomerID = customerID;
            bookLoan.IsActive = true;

            context.BookLoans.Add(bookLoan);
            context.SaveChanges();
        }

        public void CloseBookLoan(int bookLoanId)
        {
            using var context = new LibraryContext();
            var BookLoan = (from bl in context.BookLoans
                         where bl.BookLoanID == bookLoanId
                         select bl)
                    .FirstOrDefault();
            BookLoan.IsActive = false;
            context.SaveChanges();
        }

        public bool IsBookLoaned(int bookID)
        {
            using var context = new LibraryContext();
            var BookLoan = (from bl in context.BookLoans
                            where bl.BookID == bookID && bl.IsActive
                            select bl)
                    .FirstOrDefault();
            return BookLoan != null;
        }
        public BookLoan GetBookLoanByBookLoanID(int bookLoanID)
        {
            using var context = new LibraryContext();
            return (from b in context.BookLoans
                    where b.BookLoanID == bookLoanID
                    select b).FirstOrDefault();
        }
        public List<BookLoan> GetLoansByCustomerID(int customerID)
        {
            using var context = new LibraryContext();
            return (from b in context.BookLoans
                    where b.CustomerID == customerID
                    select b).ToList();
        }


    }
}
