using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksGenres> BooksGenres { get; set; }
        public virtual DbSet<BooksRental> BooksRental { get; set; }
        public virtual DbSet<Computers> Computers { get; set; }
        public virtual DbSet<ComputersRental> ComputersRental { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Visitors> Visitors { get; set; }
        public virtual DbSet<VisitorsAddress> VisitorsAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=library;Persist Security Info=True;User ID=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("books");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.AgeGroup)
                    .IsRequired()
                    .HasColumnName("ageGroup")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfPublication)
                    .HasColumnName("dateOfPublication")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasColumnName("imagePath")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsInReadingRoom).HasColumnName("isInReadingRoom");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublishingHouse)
                    .IsRequired()
                    .HasColumnName("publishingHouse")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalNumber).HasColumnName("totalNumber");
            });

            modelBuilder.Entity<BooksGenres>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdGenre })
                    .HasName("PK_books_genres");

                entity.ToTable("booksGenres");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdGenre).HasColumnName("idGenre");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BooksGenres)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_books_genres_books");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.BooksGenres)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_books_genres_genres");
            });

            modelBuilder.Entity<BooksRental>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdVisitor })
                    .HasName("PK_booksRental_1");

                entity.ToTable("booksRental");

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdVisitor).HasColumnName("idVisitor");

                entity.Property(e => e.DateHandOut)
                    .HasColumnName("dateHandOut")
                    .HasColumnType("date");

                entity.Property(e => e.DateReturn)
                    .HasColumnName("dateReturn")
                    .HasColumnType("date");

                entity.Property(e => e.HandOutBefore)
                    .HasColumnName("handOutBefore")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.BooksRental)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booksRental_books");

                entity.HasOne(d => d.IdVisitorNavigation)
                    .WithMany(p => p.BooksRental)
                    .HasForeignKey(d => d.IdVisitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_booksRental_visitors");
            });

            modelBuilder.Entity<Computers>(entity =>
            {
                entity.HasKey(e => e.IdComputer);

                entity.ToTable("computers");

                entity.Property(e => e.IdComputer).HasColumnName("idComputer");

                entity.Property(e => e.Brand).HasColumnName("brand");
            });

            modelBuilder.Entity<ComputersRental>(entity =>
            {
                entity.HasKey(e => new { e.IdComputer, e.IdVisitor })
                    .HasName("PK_computersRental_1");

                entity.ToTable("computersRental");

                entity.Property(e => e.IdComputer).HasColumnName("idComputer");

                entity.Property(e => e.IdVisitor).HasColumnName("idVisitor");

                entity.Property(e => e.EndDatetime)
                    .HasColumnName("endDatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDatetime)
                    .HasColumnName("startDatetime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdComputerNavigation)
                    .WithMany(p => p.ComputersRental)
                    .HasForeignKey(d => d.IdComputer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_computersRental_computers");

                entity.HasOne(d => d.IdVisitorNavigation)
                    .WithMany(p => p.ComputersRental)
                    .HasForeignKey(d => d.IdVisitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_computersRental_visitors");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.IdGenre);

                entity.ToTable("genres");

                entity.Property(e => e.IdGenre).HasColumnName("idGenre");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitors>(entity =>
            {
                entity.HasKey(e => e.IdVisitor);

                entity.ToTable("visitors");

                entity.Property(e => e.IdVisitor).HasColumnName("idVisitor");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnName("e-mail")
                    .HasMaxLength(50);

                entity.Property(e => e.IdAddress).HasColumnName("idAddress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK_visitors_visitorsAddress");
            });

            modelBuilder.Entity<VisitorsAddress>(entity =>
            {
                entity.HasKey(e => e.IdAddress);

                entity.ToTable("visitorsAddress");

                entity.Property(e => e.IdAddress).HasColumnName("idAddress");

                entity.Property(e => e.Apartment)
                    .HasColumnName("apartment")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasColumnName("house")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
