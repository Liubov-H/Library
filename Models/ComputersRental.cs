using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class ComputersRental
    {
        public int IdComputer { get; set; }
        public int IdVisitor { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }

        public virtual Computers IdComputerNavigation { get; set; }
        public virtual Visitors IdVisitorNavigation { get; set; }
    }
}
