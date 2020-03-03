using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface IBookAuthorRepository
    {
         Task<List<BookAuthor>> AddAuthorFromBook(List<BookAuthor> bookAuthors);
    }
}