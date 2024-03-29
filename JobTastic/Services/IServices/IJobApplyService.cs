﻿using JobTastic.Models;

namespace JobTastic.Services.IServices
{
    public interface IJobApplyService
    {
        Task<IEnumerable<JobApply>> GetAllByApplier(string id);
        Task<IEnumerable<JobApply>> GetAllByRecruiter(string id);

        Task<bool> Add(JobApply item);
        Task<IEnumerable<JobApply>> GetByJobOfferId(string id);
        Task<IEnumerable<JobApply>> GetApplication(string userId, string JobId);

        Task<JobApply> GetById(String id);
        Task Delete(string id);
    }
}