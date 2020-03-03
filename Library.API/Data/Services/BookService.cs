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
        private readonly IBookCategoryService _bookCategoryService;
        private readonly DataContext _context;

        public BookService(
            IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IBookCategoryService bookCategoryService,
            DataContext context
            )
        {
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _bookCategoryService = bookCategoryService;
            _context = context;
            _bookRepository = bookRepository;

        }

        public async Task<Book> AddBook(BookDto bookDto)
        {


            if (!await _bookRepository.BookExists(bookDto.GoogleBookId))
            {
                // List<BookAuthor> authors = GetAuthors(bookDto.Authors);

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
                var createdBook = await _bookRepository.AddBook(bookToCreate, bookDto.UserId, bookDto.BookshelfId);
                var bookCategories = await _bookCategoryService.AddCategoriesToBook(bookDto.Categories, createdBook);
                return createdBook;

            }
            else
            {
                return await _bookRepository.AddExistingBook(bookDto.GoogleBookId, bookDto.UserId, bookDto.BookshelfId);

            }
        }
    }
}