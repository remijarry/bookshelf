using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.Data;
using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/bookshelves/{userId}/books")] // why doesn't this route match the controller name "books" ? 
    // if it's specific to one bookshelf the operations probably belong on bookshelvescontroller, IMO
    public class BooksController : BaseApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IBookCategoryService _bookCategoryService; // not used
        public BooksController(IBookService bookService, IBookRepository bookRepository, IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
            _bookService = bookService;
            _bookRepository = bookRepository;

            // IMO it's a bit of a code smell when you have a controller (or service) that is operating at multiple levels of abstraction (repos vs services)
            // This is true even if they're for different things - it's especially true when they're both for the same thing (bookRepo, bookService)
        }

        [HttpGet("reading")]
        public async Task<IActionResult> GetReadingBooks(int userId)
        {
            return Ok(await _bookRepository.GetReadingBooks(userId));
        }

        [HttpGet("toread")]
        public async Task<IActionResult> GetToReadBooks(int userId)
        {
            return Ok(await _bookRepository.GetToReadBooks(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BookDto bookDto)
        {
            var createdBook = await _bookService.AddBook(bookDto); // why is this using a service not a repo?
            return Ok(); // why not return the createdBook?
        }
    }
}