using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Repositories.IRepositories;
using JobTastic.Models;
using Microsoft.EntityFrameworkCore;
using JobTastic.Data;

namespace JobTastic.Repositories
{
    internal class JobTypeRepository : IJobTypeRepository
    {
        private readonly AuthDbContext _context;

        public JobTypeRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobType>> GetAll()
        {
            return await _context.JobTypes.ToListAsync();
        }

        public async Task<JobType> GetById(string id)
        {
            return await _context.JobTypes.FirstOrDefaultAsync(x => x.JobTypeId == id);
        }

        public void Add(JobType item)
        {
            _context.Add(item);
        }

        public void Update(JobType item)
        {
            _context.Update(item);
        }

        public void Delete(JobType item)
        {
            _context.Remove(item);
        }
    }
}
