using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class BooksGenres
    {
        public int IdBook { get; set; }
        public int IdGenre { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Genres IdGenreNavigation { get; set; }
    }
}
