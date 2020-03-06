using Library.API.Core.Models;
using Library.API.Core.Services.Interfaces;
using Library.API.Data;
using Library.API.Repositories.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Core.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly DataContext _context;

        public BookCategoryService(DataContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;

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