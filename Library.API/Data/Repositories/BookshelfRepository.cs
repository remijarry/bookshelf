using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Repositories
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private readonly DataContext _context;

        public BookshelfRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateInitialBookshelves(int userId)
        {
            var bookshelves = new List<Bookshelf>()
            {
            new Bookshelf { Name = "Favourite", IsPublic = true, UserId = userId },
            new Bookshelf { Name = "Reading", IsPublic = true, UserId = userId },
            new Bookshelf { Name = "To read", IsPublic = true, UserId = userId },
            new Bookshelf { Name = "Read", IsPublic = true, UserId = userId }
        };

            _context.Bookshelves.AddRange(bookshelves);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bookshelf>> AllByUserId(int userId)
        {
            return await _context.Bookshelves.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<Bookshelf> AddBook(Book book, int userId, int bookshelfId)
        {
            var userBookshelf = await _context.Bookshelves
            .Include(bs => bs.Books)
            .FirstOrDefaultAsync(bs => bs.Id == bookshelfId && bs.UserId == userId);

            userBookshelf.AddBook(book);

            await _context.SaveChangesAsync();
            return userBookshelf;
        }

        public async Task AddExistingBook(int bookId, int userId, int bookshelfId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            var bookshelve = await _context.Bookshelves.Include(b => b.Books).FirstOrDefaultAsync(bs => bs.Id == bookshelfId);
            
            if (!bookshelve.Books.Any(b => b.BookId == book.Id))
            {
                var bookshelveBook = new BookshelfBook() { BookId = book.Id, BookshelfId = bookshelve.Id };
                _context.BookshelfBooks.Add(bookshelveBook);
                await _context.SaveChangesAsync();

            }
        }
    }
}