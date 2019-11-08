using System;
using System.Collections.Generic;
using System.Text;

namespace Library1
{
    public enum RemoveCustomerError
    {
        NoSuchCustomer,
        CustomerHasBook,
        CustomerHasLoan,
        Ok,
        CustomerHasMoneyDebt
    }
}
