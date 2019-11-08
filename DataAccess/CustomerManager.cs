using IDataInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess
{
    public class CustomerManager : ICustomerManager
    {
 
        public void AddCustomer(string CustomersName, string CustomersDateOfBirthYYYYMMDD, int CustomersMoneyDebt)

        {
            using var context = new LibraryContext();
            var customer = new Customer();
            customer.CustomersName = CustomersName;
            customer.CustomersDateOfBirthYYYYMMDD = CustomersDateOfBirthYYYYMMDD;
            customer.MoneyDebt.Add( new MoneyDebt { MoneyDebtNumber = CustomersMoneyDebt });
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public Customer GetCustomer(string customersDateOfBirthYYYYMMDD)
        {
            using var context = new LibraryContext();
            return (from c in context.Customers
                    where c.CustomersDateOfBirthYYYYMMDD == customersDateOfBirthYYYYMMDD
                    select c)
            .Include(s => s.FindAvailableBooks)
            .FirstOrDefault();
        }

        public BookLoan GetActiveLoanByCustomer(int customerID)
        {
            using var context = new LibraryContext();
            return (from c in context.BookLoans
                    where c.IsActive && c.CustomerID == customerID
                    select c)
                    .FirstOrDefault();
        }
        public MoneyDebt GetActiveMoneyDebtByCustomer(int customerID)
        {
            using var context = new LibraryContext();
            return (from c in context.MoneyDebts
                    where c.IsActive && c.CustomerID == customerID
                    select c)
                    .FirstOrDefault();
        }
        public List<Customer> GetAllCustomers()
        {
            using var context = new LibraryContext();
            return (from c in context.AllCustomers
                    select c).ToList();
        }
        public void RemoveCustomer(string customersDateOfBirthYYYYMMDD)
        {
            using var context = new LibraryContext();
            var customer = (from c in context.Customers
                                  where c.CustomersDateOfBirthYYYYMMDD == customersDateOfBirthYYYYMMDD
                            select c)
                                  .FirstOrDefault();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
