using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Data;
using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    public class BookshelvesController : BaseApiController
    {
        private readonly IBookshelfRepository _bookshelfRepository;
        private readonly IBookRepository _bookRepository;
        public BookshelvesController(IBookshelfRepository bookshelfRepository, IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _bookshelfRepository = bookshelfRepository;
        }

        [HttpGet("{id}")]
        public async Task<List<BookshelfForDisplayDto>> AllByUserId(int id)
        {
            var bookshelves = await _bookshelfRepository.AllByUserId(id);
            var bookshelvesDto = new List<BookshelfForDisplayDto>(); // can use auto mapper for that
            foreach (var bookshelf in bookshelves)
            {
                bookshelvesDto.Add(new BookshelfForDisplayDto { Id = bookshelf.Id, userId = bookshelf.UserId, Name = bookshelf.Name, Description = bookshelf.Description, IsPublic = bookshelf.IsPublic });
            }
            return bookshelvesDto;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            var book = await _bookRepository.ByGoogleId(bookDto.GoogleBookId);

            if (book == null)
            {
                var bookToCreate = new Book()
                {
                    Title = bookDto.Title,
                    Editor = bookDto.Publisher,
                    ImageLink = bookDto.ImageLink,
                    Description = bookDto.Description,
                    GoogleBookId = bookDto.GoogleBookId
                };
                var createdBook = await _bookshelfRepository.AddBook(bookToCreate, bookDto.UserId, bookDto.BookshelfId);
            }
            else
            {
                await _bookshelfRepository.AddExistingBook(book.Id, bookDto.UserId, bookDto.BookshelfId);
            }



            return StatusCode(201);
        }

    }
}