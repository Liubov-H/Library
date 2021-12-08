using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class BooksRental
    {
        public int IdBook { get; set; }
        public int IdVisitor { get; set; }
        public DateTime DateHandOut { get; set; }
        public DateTime HandOutBefore { get; set; }
        public DateTime? DateReturn { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Visitors IdVisitorNavigation { get; set; }
    }
}
