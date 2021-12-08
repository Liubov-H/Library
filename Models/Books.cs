using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class Books
    {
        public Books()
        {
            BooksGenres = new HashSet<BooksGenres>();
            BooksRental = new HashSet<BooksRental>();
        }

        public int IdBook { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string? PublishingHouse { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public string? AgeGroup { get; set; }
        public int TotalNumber { get; set; }
        public string? ImagePath { get; set; }
        public int? IsInReadingRoom { get; set; }

        public virtual ICollection<BooksGenres> BooksGenres { get; set; }
        public virtual ICollection<BooksRental> BooksRental { get; set; }
    }
}
