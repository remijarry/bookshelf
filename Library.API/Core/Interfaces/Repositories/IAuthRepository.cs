using System.Threading.Tasks;
using Library.API.Core.Models;

namespace Library.API.Repositories.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}