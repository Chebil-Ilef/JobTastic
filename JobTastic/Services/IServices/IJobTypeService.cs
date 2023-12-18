using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Services.IServices
{
    public interface IJobTypeService
    {
        Task<IEnumerable<JobType>> GetAllTypes();

        Task<JobType> GetTypeById(string id);

        Task<bool> Add(JobType item);

        Task<bool> Edit(JobType item);

        Task<bool> Delete(JobType item);
    }
}
