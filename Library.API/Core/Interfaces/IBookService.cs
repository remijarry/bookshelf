using System.Threading.Tasks;
using Library.API.DTOs;
using Library.API.Models;

namespace Library.API.Core.Interfaces
{
    public interface IBookService
    {
        Task<Book> AddBook(BookDto bookDto);
    }
}