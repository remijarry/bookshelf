using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data
{
    public interface IAuthorRepository
    {
        Task<Author> ByName(string name);
    }
}