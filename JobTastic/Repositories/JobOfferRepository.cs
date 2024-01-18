using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTastic.Repositories.IRepositories;
using JobTastic.Models;
using Microsoft.EntityFrameworkCore;
using JobTastic.Data;

namespace JobTastic.Repositories
{
    internal class JobOfferRepository : IJobOfferRepository
    {
        private readonly AuthDbContext _context;

        public JobOfferRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<IList<JobOffer>> GetAll()
        {
            return await _context.JobOffers
                .Include(u => u.jobcategory)
                .Include(u => u.JobType)
                .Include(u => u.author)
                .ToListAsync();
        }

        public async Task<JobOffer> GetById(string id)
        {
            return await _context.JobOffers
                .Include(u => u.jobcategory)
                .Include(u => u.JobType)
                .Include(u => u.author)
                .FirstOrDefaultAsync(x => x.jobOfferId == id);
        }

        public void Add(JobOffer item)
        {
            _context.Add(item);
        }

        public void Update(JobOffer item)
        {
            _context.Update(item);
        }

        public void Delete(JobOffer item)
        {
            _context.Remove(item);
        }
    }
}
