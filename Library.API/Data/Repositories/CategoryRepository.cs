using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Microsoft.EntityFrameworkCore;

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