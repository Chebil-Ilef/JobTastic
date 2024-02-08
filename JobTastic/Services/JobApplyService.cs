using JobTastic.Areas.Identity.Data;
using JobTastic.Data;
using JobTastic.Models;
using JobTastic.Repositories.IRepositories;
using JobTastic.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace JobTastic.Services
{
    public class JobApplyService : IJobApplyService

    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJobApplyRepository _jobApplyRepo;
        private readonly AuthDbContext _db;
        private readonly IApplicationUserRepository _applicationUserRepo;
        private readonly IUnitOfWork _unitOfWork;

        public JobApplyService(
            IJobApplyRepository jobApplyRepo,
            AuthDbContext db,
            IUnitOfWork unitOfWork,
            IApplicationUserRepository applicationUserRepo)
        {
            _applicationUserRepo = applicationUserRepo;
            _jobApplyRepo = jobApplyRepo;
            _db = db;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<JobApply>> GetAllByApplier(string id)
        {
            return await _jobApplyRepo.GetByApplier(id);
        }

        public async Task<IEnumerable<JobApply>> GetAllByRecruiter(string id) {
            return await _jobApplyRepo.GetByRecruiter(id);
        }
        public async Task<bool> Add(JobApply item)
        {
            item.sent = DateTime.Now;
            
            _jobApplyRepo.Add(item);
            await _unitOfWork.Save();
            return true;
        }
        public async Task<IEnumerable<JobApply>> GetByJobOfferId(string id)
        {
            return await _jobApplyRepo.GetByJobOfferId(id);
        }
        public async Task<IEnumerable<JobApply>> GetApplication(string userId,string JobId)
        {
            return await _jobApplyRepo.GetApplication(userId, JobId);
        }

}
}
