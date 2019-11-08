using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Diagnostics;
using IDataInterface;


namespace DataAccess
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-UIJVU0KV;DataBase=Library;Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookShelfAisle> BookShelfAisles { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Book> Menu { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        public DbSet<LoanTime> LoanTimes { get; set; }
        public DbSet<Customer> AllCustomers { get; set; }
        public DbSet<MoneyDebt> MoneyDebts { get; set; }

    }
}
