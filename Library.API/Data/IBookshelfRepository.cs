using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface IBookshelfRepository
    {
        Task CreateInitialBookshelves(int userId);

        Task<List<Bookshelf>> AllByUserId(int userId);
    }
}