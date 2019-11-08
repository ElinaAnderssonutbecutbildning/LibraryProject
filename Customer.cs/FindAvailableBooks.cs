using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class FindAvailableBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FindAvailableBooksID { get; set; }
        public int CustomerID { get; set; }
        public string CustormerName { get; set; }
        public int LoanTimeID { get; set; }
        public LoanTime LoanTime { get; set; }
        public int BookID { get; set; }
        public  Book Book { get; set; }
    }
}
