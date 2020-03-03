using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Core.Interfaces
{
    public interface IBookCategoryService
    {
         Task<List<BookCategory>> AddCategoriesToBook(List<string> categories, Book book);
    }
}