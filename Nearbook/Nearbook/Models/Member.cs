using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nearbook.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Username { get; set; }
        public string email { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}