using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface IBookshelfRepository
    {
        Task CreateInitialBookshelves(int userId);

        Task<List<Bookshelf>> AllByUserId(int userId);
    }
}