using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPrice { get; set; }
        public int ShelfID { get; set; }
        public Shelf Shelf { get; set; }
        public int FindAvailableBooksID { get; set; }
         public ICollection<BookLoan> BookLoan { get; set; }
    }
}
