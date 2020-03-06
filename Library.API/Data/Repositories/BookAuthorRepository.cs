using Library.API.Core.Models;
using Library.API.Repositories.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly DataContext _context;

        public BookAuthorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BookAuthor>> AddAuthorFromBook(List<BookAuthor> bookAuthors)
        {
            await _context.BookAuthors.AddRangeAsync(bookAuthors);
            await _context.SaveChangesAsync();

            return bookAuthors;
        }
    }
}