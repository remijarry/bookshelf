using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Data;
using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/bookshelves")]
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

    }
}