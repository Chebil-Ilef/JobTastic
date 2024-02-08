﻿using JobTastic.Data;
using JobTastic.Models;
using JobTastic.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace JobTastic.Repositories
{
    internal class JobApplyRepository : IJobApplyRepository
    {
        private readonly AuthDbContext _context;

        public JobApplyRepository(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<IList<JobApply>> GetByApplier(string applierId)
        {
            return await _context.JobApplies
                .Include(x => x.JobOffer)
                .Include(x => x.Applier)
                .Where(x => x.ApplierId == applierId)
                .ToListAsync();
        }
        public async Task<IList<JobApply>> GetByRecruiter(string RecruiterId)
        {
            return await _context.JobApplies
                .Include(x => x.JobOffer)
                .Include(x => x.Applier)
                .Where(x => x.JobOffer.author.Id == RecruiterId)
                .ToListAsync();
        }
        public void Add(JobApply item)
        {
            _context.Add(item);
        }
        public async Task<IEnumerable<JobApply>> GetByJobOfferId(string id)
        {
            return await _context.JobApplies
               .Include(x => x.JobOffer)
               .Include(x => x.Applier)
               .Where(x => x.JobOfferId == id)
               .ToListAsync();
        }
    }
}