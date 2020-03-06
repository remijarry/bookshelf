using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface IBookRepository
    {
        Task<Book> ByGoogleId(string googleId);

        Task<List<Book>> GetToReadBooks(int userId);
        Task<List<Book>> GetReadingBooks(int userId);
        Task<bool> BookExists(string googleId);

        Task<Book> AddBook(Book book, int userId, int bookshelfId);
        Task<Book> AddExistingBook(string googleBookId, int userId, int bookshelfId);
        Task<Book> GetById(int bookId);
    }
}