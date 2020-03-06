using Library.API.Core.Models;
using Library.API.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Category> ByName(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}