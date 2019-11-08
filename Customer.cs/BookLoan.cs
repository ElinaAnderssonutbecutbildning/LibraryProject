using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class BookLoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookLoanID { get; set; }
        public int GetBookLoanByBookLoanID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public bool IsActive { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }


    }
}
