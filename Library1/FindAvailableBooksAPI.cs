using System;
using System.Collections.Generic;
using System.Linq;
using IDataInterface;



namespace Library1
{
    public class FindAvailableBooksAPI
    {
        IFindAvailableBooksManager findAvailableBooksManager;
        IBookManager bookManager;
        public FindAvailableBooksAPI(IFindAvailableBooksManager findAvailableBooksManager, IBookManager bookManager)
        {
            this.findAvailableBooksManager = findAvailableBooksManager;
            this.bookManager = bookManager;
        }

        private static IEnumerable<Book> FindAvailableBookThisLoanTime(int customerLoanOfBooks, LoanTime loanTime,
                                                                       List<Book> books)
        {
            return books.Where(b =>
                                !loanTime.FindAvailableBookss
                                    .Any(f => f.BookID == b.BookID));
        }
    }
}
