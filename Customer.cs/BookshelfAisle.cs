using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class BookShelfAisle
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookshelfAisleID { get; set; }
        public int BookshelfAisleNumber { get; set; }
        public int ShelfID { get; set; }
        public ICollection<Shelf> Shelf { get; set; }

    }
}
