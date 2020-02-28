using System.Threading.Tasks;
using Library.API.Data;
using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("reading/{userId}")]
        public async Task<IActionResult> GetReadingBooks(int userId)
        {
            return Ok(await _bookRepository.GetReadingBooks(userId));
        }

        [HttpGet("toread/{userId}")]
        public async Task<IActionResult> GetToReadBooks(int userId)
        {
            return Ok(await _bookRepository.GetToReadBooks(userId));
        }
    }
}