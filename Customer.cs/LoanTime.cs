using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class LoanTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanTimeID { get; set; }
        public int FindAvailableBooksID { get; set; }
        public DateTime Start { get; set; }

        public ICollection<FindAvailableBooks> FindAvailableBookss { get; set; }
    }
}
