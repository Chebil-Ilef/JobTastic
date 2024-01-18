using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Services.IServices
{
    public interface IJobCategoryService
    {
        Task<IEnumerable<JobCategory>> GetAllCategories();

        Task<JobCategory> GetCategoryById(string id);

        Task<bool> Add(JobCategory item);

        Task<bool> Edit(JobCategory item);

        Task<bool> Delete(JobCategory item);
    }
}
