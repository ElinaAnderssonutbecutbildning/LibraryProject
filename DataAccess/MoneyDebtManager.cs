using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MoneyDebtManager : IMoneyDebtManager
    {
        public void AddMoneyDebt(int moneyDebtNumer)
        {
            using var context = new LibraryContext();
            var moneyDebt = new MoneyDebt();
            moneyDebt.MoneyDebtNumber = moneyDebtNumer;
            context.MoneyDebts.Add(moneyDebt);
            context.SaveChanges();
        }
        public List<MoneyDebt> GetAllMoneyDebts()
        {
            using var context = new LibraryContext();
            return (from m in context.MoneyDebts
                    select m)
                    .Include(m => m.CustomerID)
                    .ToList();
        }
        public MoneyDebt GetMoneyDebtByMoneyDebtNumber(int moneyDebtNumber)
        {
            using var context = new LibraryContext();
            return (from m in context.MoneyDebts
                    where m.MoneyDebtNumber == moneyDebtNumber
                    select m)
                    .FirstOrDefault();
        }

        public void RemoveMoneyDebt(int moneyDebtID)
        {
            using var context = new LibraryContext();
            var moneyDebt = (from m in context.MoneyDebts
                         where m.MoneyDebtID == moneyDebtID
                             select m).FirstOrDefault();
            context.MoneyDebts.Remove(moneyDebt);
            context.SaveChanges();
        }
        public MoneyDebt CreateActiveMoneyDebt(int customerID )
        {
            using var context = new LibraryContext();
            var moneyDebt = new MoneyDebt();
            moneyDebt.IsActive = true;
            moneyDebt.CustomerID = customerID;
            context.MoneyDebts.Add(moneyDebt);
            context.SaveChanges();
            return moneyDebt;
        }

        public MoneyDebt GetActiveMoneyDebt(int customerID)
        {
            using var context = new LibraryContext();
            return (from m in context.MoneyDebts
                    where m.CustomerID == customerID && m.IsActive
                    select m)
                    .FirstOrDefault();
        }

        public void UpdateMoneyDebt(int moneyDebtID, int moneyDebtNumber)
        {
            using var context = new LibraryContext();
            var debt = (from m in context.MoneyDebts
                    where m.MoneyDebtID == moneyDebtID
                    select m)
                    .FirstOrDefault();
            debt.MoneyDebtNumber = moneyDebtNumber;
            context.SaveChanges();
        }

       
    }
}