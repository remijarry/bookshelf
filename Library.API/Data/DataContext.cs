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

        public DbSet<BookshelfBook> BookshelfBooks { get; set; }
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
        }

    }
}