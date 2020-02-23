using System;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Bookshelf> Bookshelves { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region Configuration
            modelBuilder.Entity<BookshelfBook>().HasKey(b => new { b.BookId, b.BookshelfId });

            modelBuilder.Entity<BookshelfBook>().HasOne(b => b.Book)
                .WithMany(b => b.BookshelveBooks)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookshelfBook>().HasOne(b => b.Bookshelf)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.BookshelfId);

            modelBuilder.Entity<BookAuthor>().HasKey(b => new { b.BookId, b.AuthorId });

            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<BookAuthor>().HasOne(b => b.Author)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(b => b.BookId);
            #endregion

            #region Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Fantasy"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Science fiction"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror"
                },
                new Genre
                {
                    Id = 4,
                    Name = "Western"
                },
                new Genre
                {
                    Id = 5,
                    Name = "Romance"
                },
                new Genre
                {
                    Id = 6,
                    Name = "Thriller"
                },
                new Genre
                {
                    Id = 7,
                    Name = "Mystery"
                },
                new Genre
                {
                    Id = 8,
                    Name = "Detective"
                },
                new Genre
                {
                    Id = 9,
                    Name = "Dystopia"
                },
                new Genre
                {
                    Id = 10,
                    Name = "Memoir"
                },
                new Genre
                {
                    Id = 11,
                    Name = "Biography"
                }
            );
            #endregion

            #region Author
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Aurélien",
                    LastName = "Barrau",
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Hugo",
                    LastName = "Clément",
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Paul",
                    LastName = "Dubois",
                },
                new Author
                {
                    Id = 4,
                    FirstName = "Florian",
                    LastName = "Zeller",
                }
            );
            #endregion

            #region Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Tous les hommes n'habitent pas le monde de la même façon",
                    Editor = "Editions de l'Olivier",
                    HaveRead = true,
                    Length = 233,
                    DateStarted = new DateTime(2020, 02, 10),
                    DateFinished = new DateTime(2020, 02, 15),
                },
                new Book
                {
                    Id = 2,
                    Title = "Comment j'ai arrêté de manger les animaux",
                    Editor = "Le Seuil",
                    Reading = true,
                    Length = 180,
                    DateStarted = new DateTime(2020, 02, 16),
                },
                new Book
                {
                    Id = 3,
                    Title = "Le plus grand défi de l'histoire de l'humanité",
                    Editor = "Michel Lafon",
                    HaveRead = true,
                    Length = 143,
                    DateStarted = new DateTime(2020, 02, 3),
                    DateFinished = new DateTime(2020, 02, 13)
                },
                new Book
                {
                    Id = 4,
                    Title = "La jouissance",
                    Editor = "Gallimard",
                    ToRead = true,
                    Length = 160,
                }
            );
            #endregion

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor
                {
                    AuthorId = 1,
                    BookId = 3
                },
                new BookAuthor
                {
                    AuthorId = 2,
                    BookId = 2
                },
                new BookAuthor
                {
                    AuthorId = 3,
                    BookId = 1
                },
                new BookAuthor
                {
                    AuthorId = 4,
                    BookId = 4
                }
            );
        }

    }
}