using IDataInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Moq;

namespace DataAccess
{
    public class FindAvailableBooksManager
    {
        public LoanTime FindAvailableBooks(string nameOfAvailableBook, DateTime start)
        {
            using var context = new LibraryContext();
            var loantimes = (from s in context.LoanTimes
                             where 
                                s.FindAvailableBookss.Any(f => f.BookID == f.BookID)
                                && s.Start >= start
                             orderby s.Start
                             select s);
            return loantimes.FirstOrDefault();
        }
    }
}
