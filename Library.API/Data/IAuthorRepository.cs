using System.Threading.Tasks;
using Library.API.Models;

namespace Library.API.Data // move to Core.Interfaces; same with all the interfaces in this folder
{
    public interface IAuthorRepository
    {
        Task<Author> ByName(string name);
    }
}