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
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IBookCategoryService _bookCategoryService;
        public BooksController(IBookService bookService, IBookRepository bookRepository, IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
            _bookService = bookService;
            _bookRepository = bookRepository;
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
            var createdBook = await _bookService.AddBook(bookDto);
            return Ok();
        }
    }
}