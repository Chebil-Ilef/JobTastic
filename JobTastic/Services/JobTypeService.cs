﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTastic.Helpers;
using JobTastic.Models;
using JobTastic.Repositories.IRepositories;
using JobTastic.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace JobTastic.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public JobTypeService(IJobTypeRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JobType>> GetAllTypes()
        {
            return await _repo.GetAll();
        }

        public async Task<JobType> GetTypeById(string id)
        {
            return await _repo.GetById(id);
        }

        public async Task<bool> Add(JobType item)
        {
            _repo.Add(item);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> Edit(JobType item)
        {
            var category = await _repo.GetById(item.JobTypeId);
            category.Name = item.Name;

            try
            {
                _repo.Update(category);
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(JobType item)
        {
            _repo.Delete(item);
            await _unitOfWork.Save();
            return true;
        }
    }
}
