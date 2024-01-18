using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Repositories.IRepositories
{
    public interface IJobCategoryRepository
    {
        Task<IEnumerable<JobCategory>> GetAll();

        Task<JobCategory> GetById(string id);

        void Add(JobCategory item);

        void Update(JobCategory item);

        void Delete(JobCategory item);
    }
}
