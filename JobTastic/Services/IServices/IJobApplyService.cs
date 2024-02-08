using JobTastic.Models;

namespace JobTastic.Services.IServices
{
    public interface IJobApplyService
    {
        Task<IEnumerable<JobApply>> GetAllByApplier(string id);
        Task<IEnumerable<JobApply>> GetAllByRecruiter(string id);

        Task<bool> Add(JobApply item);
        Task<IEnumerable<JobApply>> GetByJobOfferId(string id);
    }
}
