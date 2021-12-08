using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class Visitors
    {
        public Visitors()
        {
            BooksRental = new HashSet<BooksRental>();
            ComputersRental = new HashSet<ComputersRental>();
        }

        public int IdVisitor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EMail { get; set; }
        public string? Password { get; set; }
        public int? IdAddress { get; set; }

        public virtual VisitorsAddress IdAddressNavigation { get; set; }
        public virtual ICollection<BooksRental> BooksRental { get; set; }
        public virtual ICollection<ComputersRental> ComputersRental { get; set; }
    }
}
