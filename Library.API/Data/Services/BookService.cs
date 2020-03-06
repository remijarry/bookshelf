using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.DTOs;
using Library.API.Models;

namespace Library.API.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository
            )
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;

        }

        public async Task<Book> AddBook(BookDto bookDto)
        {
            if (!await _bookRepository.BookExists(bookDto.GoogleBookId))
            {
                List<Author> authors = await GetAuthors(bookDto.Authors);
                List<Category> categoriesToAdd = await GetCategories(bookDto.Categories);

                // todo : use auto mapper
                var bookToCreate = new Book()
                {
                    Title = bookDto.Title,
                    Publisher = bookDto.Publisher,
                    ImageLink = bookDto.ImageLink,
                    Description = bookDto.Description,
                    GoogleBookId = bookDto.GoogleBookId,
                    PageCount = bookDto.PageCount,

                };

                foreach (var category in categoriesToAdd)
                {
                    bookToCreate.Categories.Add(new BookCategory() { Book = bookToCreate, Category = category });
                }

                foreach (var author in authors)
                {
                    bookToCreate.BookAuthors.Add(new BookAuthor() { Book = bookToCreate, Author = author });
                }

                var createdBook = await _bookRepository.AddBook(bookToCreate, bookDto.UserId, bookDto.BookshelfId);
                return createdBook;
            }
            else
            {
                return await _bookRepository.AddExistingBook(bookDto.GoogleBookId, bookDto.UserId, bookDto.BookshelfId);
            }
        }

        public async Task<Book> GetById(int bookId)
        {
            return await _bookRepository.GetById(bookId);
        }

        public Task<List<Book>> GetReadingBooks(int userId)
        {
            return _bookRepository.GetReadingBooks(userId);
        }

        public Task<List<Book>> GetToReadBooks(int userId)
        {
            return _bookRepository.GetToReadBooks(userId);
        }

        private async Task<List<Author>> GetAuthors(List<string> authors)
        {
            var authorsToReturn = new List<Author>();
            foreach (var authorName in authors)
            {
                var existingAuthor = await _authorRepository.ByName(authorName);
                if (existingAuthor == null)
                {
                    var newAuthor = new Author() { Name = authorName.TrimEnd() };
                    authorsToReturn.Add(newAuthor);
                }
                else
                {
                    authorsToReturn.Add(existingAuthor);
                }
            }
            return authorsToReturn;
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