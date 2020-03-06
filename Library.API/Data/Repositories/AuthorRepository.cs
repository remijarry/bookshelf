using Library.API.Core.Models;
using Library.API.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Author> ByName(string name)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}