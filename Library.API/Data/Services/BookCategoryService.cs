using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.Models;

namespace Library.API.Data.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly DataContext _context;

        public BookCategoryService(DataContext context, IBookCategoryRepository bookCategoryRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _bookCategoryRepository = bookCategoryRepository;

        }

        public async Task<List<BookCategory>> AddCategoriesFromBook(List<string> categories, Book book)
        {
            List<Category> categoriesToAdd = await GetCategories(categories);
            foreach (var category in categoriesToAdd)
            {
                book.Categories.Add(new BookCategory() {Book = book, Category = category});
            }

            await _context.SaveChangesAsync();
            return book.Categories;
        }

        private async Task<List<Category>> GetCategories(List<string> categories)
        {
            List<Category> categoriesToReturn = new List<Category>();
            foreach (var categoryName in categories)
            {
                var existingCategory = await _categoryRepository.ByName(categoryName);
                if (existingCategory == null)
                {
                    var newCategory = new Category() { Name = categoryName.TrimEnd() };
                    categoriesToReturn.Add(newCategory);
                }
                else
                {
                    categoriesToReturn.Add(existingCategory);
                }
            }

            return categoriesToReturn;
        }
    }
}