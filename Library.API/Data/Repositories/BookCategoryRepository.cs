using Library.API.Core.Models;
using Library.API.Repositories.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly DataContext _context;
        public BookCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookCategory>> AddCategoriesFromBook(List<BookCategory> bookCategories)
        {
            await _context.BookCategories.AddRangeAsync(bookCategories);
            await _context.SaveChangesAsync();

            return bookCategories;
        }
    }
}