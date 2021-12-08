using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class Genres
    {
        public Genres()
        {
            BooksGenres = new HashSet<BooksGenres>();
        }

        public int IdGenre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
    }
}
