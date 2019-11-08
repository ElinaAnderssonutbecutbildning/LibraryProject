using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IDataInterface
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string CustomersName { get; set; }
        public string CustomersAddress { get; set; }
        public string CustomersDateOfBirthYYYYMMDD { get; set; }
        public int MoneyDebtID { get; set; }
        public ICollection<MoneyDebt> MoneyDebt { get; set; }
        public int FindAvailableBooksID { get; set; }

        public FindAvailableBooks FindAvailableBooks { get; set; }
        public int BookLoansID { get; set; }

        public ICollection<BookLoan> BookLoans { get; set; }
    }
}
