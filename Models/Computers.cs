using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class Computers
    {
        public Computers()
        {
            ComputersRental = new HashSet<ComputersRental>();
        }

        public int IdComputer { get; set; }
        public string Brand { get; set; }

        public virtual ICollection<ComputersRental> ComputersRental { get; set; }
    }
}
