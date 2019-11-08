using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class MoneyDebt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MoneyDebtID { get; set; }
        public int MoneyDebtNumber { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public bool IsActive { get; set; }
        public int GetActiveMoneyDebtByCustomer { get; set; }
        public int GetActiveMoneyDebt { get; set; }
    }
}
