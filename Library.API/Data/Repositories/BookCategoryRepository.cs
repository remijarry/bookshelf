using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly DataContext _context;
        private readonly ICategoryRepository _categoryRepository;
        public BookCategoryRepository(DataContext context, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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