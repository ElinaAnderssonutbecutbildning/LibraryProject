using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface ICustomerManager
    {
        public void AddCustomer(string CustomersName, string CustomersDateOfBirthYYYYMMDD, int MoneyDebt);
        Customer GetCustomer(string customersDateOfBirthYYYYMMDD);
        void RemoveCustomer(string customerDateOfBirthYYYYMMDD);
        
    }
}
