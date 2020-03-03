using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> ByGoogleId(string googleId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.GoogleBookId == googleId);
        }

        public async Task<List<Book>> GetReadingBooks(int userId)
        {
            return await _context.Books.Where(b => b.BookshelveBooks.Any(b => b.Bookshelf.Name == "Reading")).ToListAsync();
        }

        public async Task<List<Book>> GetToReadBooks(int userId)
        {
            return await _context.Books.Where(b => b.BookshelveBooks.Any(b => b.Bookshelf.Name == "To read")).ToListAsync();
        }

        public async Task<bool> BookExists(string googleId)
        {
            return await _context.Books.AnyAsync(b => b.GoogleBookId == googleId);
        }

        public async Task<Book> AddBook(Book book, int userId, int bookshelfId)
        {
            var userBookshelf = await _context.Bookshelves
            .Include(bs => bs.Books)
            .FirstOrDefaultAsync(bs => bs.Id == bookshelfId && bs.UserId == userId);

            userBookshelf.AddBook(book);

            await _context.SaveChangesAsync();
            return await _context.Books.Include(b => b.BookAuthors).Include(b => b.Categories).FirstOrDefaultAsync(b => b.Id == book.Id);
        }

        public async Task<Book> AddExistingBook(string googleBookId, int userId, int bookshelfId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.GoogleBookId == googleBookId);
            var bookshelve = await _context.Bookshelves.Include(b => b.Books).FirstOrDefaultAsync(bs => bs.Id == bookshelfId);

            if (!bookshelve.Books.Any(b => b.BookId == book.Id))
            {
                var bookshelveBook = new BookshelfBook() { BookId = book.Id, BookshelfId = bookshelve.Id };
                _context.BookshelfBooks.Add(bookshelveBook);
                await _context.SaveChangesAsync();

            }

            return book;
        }
    }
}