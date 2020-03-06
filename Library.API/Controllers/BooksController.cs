using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.Data;
using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/bookshelves/{userId}/books")]
    public class BooksController : BaseApiController
    {
        private readonly IBookService _bookService;
        private readonly IBookCategoryService _bookCategoryService;
        public BooksController(IBookService bookService, IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
            _bookService = bookService;
        }

        [HttpGet("{bookId}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var book = await _bookService.GetById(bookId);
            return new JsonResult(book);
        }


        [HttpGet("reading")]
        public async Task<IActionResult> GetReadingBooks(int userId)
        {
            return Ok(await _bookService.GetReadingBooks(userId));
        }

        [HttpGet("toread")]
        public async Task<IActionResult> GetToReadBooks(int userId)
        {
            return Ok(await _bookService.GetToReadBooks(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BookDto bookDto)
        {
            var createdBook = await _bookService.AddBook(bookDto);
            return Ok(); // todo: return bookDto
        }
    }
}