using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Core.Services.Interfaces
{
    public interface IBookCategoryService
    {
         Task<List<BookCategory>> AddCategoriesFromBook(List<string> categories, Book book);
    }
}