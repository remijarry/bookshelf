using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.DTOs;
using Library.API.Core.Models;

namespace Library.API.Core.Services.Interfaces
{
    public interface IBookService
    {

        Task<Book> GetById(int bookId);

        Task<Book> AddBook(BookDto bookDto);

        Task<List<Book>> GetReadingBooks(int userId);

        Task<List<Book>> GetToReadBooks(int userId);
    }
}