using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface ICategoryRepository
    {
        Task<Category> ByName(string name);

    }
}