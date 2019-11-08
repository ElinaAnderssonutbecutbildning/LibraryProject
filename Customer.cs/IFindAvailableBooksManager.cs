using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IFindAvailableBooksManager
    {
        List<LoanTime> GetLoanTimeFrom(DateTime start);
    }
}
