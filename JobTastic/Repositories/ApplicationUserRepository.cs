using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;
using JobTastic.Data;
using Microsoft.EntityFrameworkCore;
using JobTastic.Repositories.IRepositories;
using JobTastic.Areas.Identity.Data;

namespace JobTastic.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AuthDbContext _context;

        public ApplicationUserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _context.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetById(string id)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
