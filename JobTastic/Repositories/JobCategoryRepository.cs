using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Repositories.IRepositories;
using JobTastic.Models;
using Microsoft.EntityFrameworkCore;
using JobTastic.Data;

namespace JobTastic.Repositories
{
    internal class JobCategoryRepository : IJobCategoryRepository
    {
        private readonly AuthDbContext _context;

        public JobCategoryRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobCategory>> GetAll()
        {
            return await _context.JobCategories.ToListAsync();
        }

        public async Task<JobCategory> GetById(string id)
        {
            return await _context.JobCategories.FirstOrDefaultAsync(x => x.JobCategoryId == id);
        }

        public void Add(JobCategory item)
        {
            _context.Add(item);
        }

        public void Update(JobCategory item)
        {
            _context.Update(item);
        }

        public void Delete(JobCategory item)
        {
            _context.Remove(item);
        }
    }
}
