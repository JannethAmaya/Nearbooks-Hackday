using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nearbook.Models
{
    public enum Status
    {
        requested, active, completed, cancelled
    }
    public class Borrow
    {
        public int BorrowID { get; set; }
        public string BookID { get; set; }
        public int MemberID { get; set; }
        public Status? Status { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}