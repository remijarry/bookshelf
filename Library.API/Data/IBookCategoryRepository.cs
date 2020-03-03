using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface IBookCategoryRepository
    {
         Task<List<BookCategory>> AddCategoriesFromBook(List<BookCategory> bookCategories);
    }
}