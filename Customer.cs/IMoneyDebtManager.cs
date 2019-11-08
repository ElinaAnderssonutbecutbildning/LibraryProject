using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IMoneyDebtManager
    {
        void AddMoneyDebt(int moneyDedtNumber);
        MoneyDebt GetMoneyDebtByMoneyDebtNumber(int moneyDebtNumber);
        void RemoveMoneyDebt(int moneyDebtID);
        List<MoneyDebt> GetAllMoneyDebts();
        MoneyDebt CreateActiveMoneyDebt(int customerID);
        MoneyDebt GetActiveMoneyDebt(int customerID);
        void UpdateMoneyDebt(int moneyDebtID, int moneyDebtNumber);
    }
}
