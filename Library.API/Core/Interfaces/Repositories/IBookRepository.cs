using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
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