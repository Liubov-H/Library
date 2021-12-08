using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class VisitorsAddress
    {
        public VisitorsAddress()
        {
            Visitors = new HashSet<Visitors>();
        }

        public int IdAddress { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string? Apartment { get; set; }

        public virtual ICollection<Visitors> Visitors { get; set; }
    }
}
