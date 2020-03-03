using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Core.Interfaces
{
    public interface IBookAuthorService
    {
         Task<List<BookAuthor>> AddAuthorsFromBook(List<string> authors, Book book);
         
    }
}