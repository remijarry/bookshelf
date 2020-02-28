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
    }
}