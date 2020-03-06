using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Core.Services.Interfaces
{
    public interface IBookAuthorService
    {
         Task<List<BookAuthor>> AddAuthorsFromBook(List<string> authors, Book book);
         
    }
}