using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface IAuthorRepository
    {
        Task<Author> ByName(string name);
    }
}