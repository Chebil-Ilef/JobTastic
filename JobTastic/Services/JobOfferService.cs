using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTastic.Areas.Identity.Data;
using JobTastic.Data;
using JobTastic.Helpers;
using JobTastic.Models;
using JobTastic.Repositories.IRepositories;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobTastic.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJobOfferRepository _jobOfferRepo;
        private readonly IJobCategoryRepository _jobCategoryRepo;
        private readonly IJobTypeRepository _jobTypeRepo;
        private readonly AuthDbContext _db;
        private readonly IApplicationUserRepository _applicationUserRepo;
        private readonly IUnitOfWork _unitOfWork;

        public JobOfferService(
            IJobOfferRepository jobOfferRepo,
            IJobCategoryRepository jobCategoryRepo,
            IJobTypeRepository jobTypeRepo,
            AuthDbContext db,
            IUnitOfWork unitOfWork,
            IApplicationUserRepository applicationUserRepo)
        {
            _applicationUserRepo = applicationUserRepo;
            _jobOfferRepo = jobOfferRepo;
            _jobCategoryRepo = jobCategoryRepo;
            _jobTypeRepo = jobTypeRepo;
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<JobOffer>> GetAllOffers()
        {
            return await _jobOfferRepo.GetAll();
        }

        public async Task<JobOffer> GetOfferById(string id)
        {
            return await _jobOfferRepo.GetById(id);
        }

        public async Task<bool> Add(JobOffer item)
        {
            item.Submitted = DateTime.Now;
            item.LastEdit = DateTime.Now;

            _jobOfferRepo.Add(item);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<bool> Edit(JobOffer item)
        {
            var offer = await _jobOfferRepo.GetById(item.jobOfferId);
            offer.jobcategory = await _jobCategoryRepo.GetById(item.JobCategoryId);
            offer.JobType = await _jobTypeRepo.GetById(item.JobTypeId);
            offer.Title = item.Title;
            offer.Description = item.Description;
            offer.LastEdit = DateTime.Now;

            try
            {
                _jobOfferRepo.Update(offer);
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(JobOffer item)
        {
            _jobOfferRepo.Delete(item);
            await _unitOfWork.Save();
            return true;
        }

        public async Task<IEnumerable<JobOffer>> GetMostPopularOffers()
        {
            return (await _jobOfferRepo.GetAll())
                .OrderByDescending(m => m.Visits)
                .Take(5);
        }

        public async Task<IEnumerable<JobOffer>> GetOffersContainingPhrase(string phrase)
        {
            phrase = phrase.ToLower();
            var offers = await _jobOfferRepo.GetAll();
            return offers.Where(c => c.Title.ToLower().Contains(phrase)
                                     || c.Description.ToLower().Contains(phrase)
                                     || c.JobType.Name.ToLower().Contains(phrase)
                                     || c.jobcategory.Name.ToLower().Contains(phrase)
                                     || c.author.Email.ToLower().Contains(phrase));
        }
        public async Task<bool> IsInRole(ApplicationUser user, string roleName)
        {
            if (user == null)
            {
                return false;
            }

            return await _userManager.IsInRoleAsync(user, roleName);
        }
        public async Task<bool> CanUserEditOffer(string userId, string offerId)
        {
            var user = await _applicationUserRepo.GetById(userId);
            var offer = await _jobOfferRepo.GetById(offerId);


            return offer.author.Id == user.Id;
        }

        public async Task<bool> IncreaseOfferViews(JobOffer offer)
        {
            offer.Visits += 1;
            _jobOfferRepo.Update(offer);
            await _unitOfWork.Save();
            return true;
        }

    }
}
