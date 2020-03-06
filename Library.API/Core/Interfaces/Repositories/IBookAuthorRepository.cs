using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface IBookAuthorRepository
    {
         Task<List<BookAuthor>> AddAuthorFromBook(List<BookAuthor> bookAuthors);
    }
}