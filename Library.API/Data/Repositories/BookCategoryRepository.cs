using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly DataContext _context;
        private readonly ICategoryRepository _categoryRepository; // unused - remove
        public BookCategoryRepository(DataContext context, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository; // repositories shouldn't use other repositories, only the context, typically (fortunately it's not used)
            _context = context;
        }

        public async Task<List<BookCategory>> AddCategoriesToBook(List<BookCategory> bookCategories)
        {
            await _context.BookCategories.AddRangeAsync(bookCategories);
            await _context.SaveChangesAsync();

            return bookCategories;
        }
    }
}