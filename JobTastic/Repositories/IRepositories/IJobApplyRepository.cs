using JobTastic.Models;

namespace JobTastic.Repositories.IRepositories
{
    public interface IJobApplyRepository
    {
        Task<IList<JobApply>> GetByApplier(string applierId);
        Task<IList<JobApply>> GetByRecruiter(string RecruiterId);
        void Add(JobApply item);
        Task<IEnumerable<JobApply>> GetByJobOfferId(string id);
        Task<IEnumerable<JobApply>> GetApplication(string userId, string JobId);
        Task<JobApply> GetById(string id);
        void Delete(JobApply jobDelete);
    }
}