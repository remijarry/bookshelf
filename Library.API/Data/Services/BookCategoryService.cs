using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.Models;

namespace Library.API.Data.Services // Services don't belong in Data - they are higher level of abstraction. Maybe put in Core.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<List<BookCategory>> AddCategoriesToBook(List<string> categories, Book book)
        {
            List<Category> categoriesToAdd = await GetCategories(categories); // this list can probably be cached in memory for a long time
            List<BookCategory> bookCategories = new List<BookCategory>();
            foreach (var category in categoriesToAdd)
            {
                bookCategories.Add(new BookCategory() { Book = book, Category = category });
            }

            bookCategories = await _bookCategoryRepository.AddCategoriesToBook(bookCategories);

            return bookCategories;
        }

        private async Task<List<Category>> GetCategories(List<string> categories)
        {
            List<Category> categoriesToReturn = new List<Category>();
            foreach (var categoryName in categories)
            {
                var existingCategory = await _categoryRepository.ByName(categoryName); // this potentially makes a lot of db calls
                if (existingCategory == null)
                {
                    var newCategory = new Category() { Name = categoryName.Trim() };
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