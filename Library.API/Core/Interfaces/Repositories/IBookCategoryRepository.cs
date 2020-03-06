using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface IBookCategoryRepository
    {
         Task<List<BookCategory>> AddCategoriesFromBook(List<BookCategory> bookCategories);
    }
}