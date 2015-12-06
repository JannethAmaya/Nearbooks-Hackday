using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nearbook.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public int Copies { get; set; }
        public int Days { get; set; }
        public bool IsAvailable { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}