using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface ICategoryRepository
    {
        Task<Category> ByName(string name);

    }
}