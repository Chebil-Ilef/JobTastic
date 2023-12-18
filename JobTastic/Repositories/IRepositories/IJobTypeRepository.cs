using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Repositories.IRepositories
{
    public interface IJobTypeRepository
    {
        Task<IEnumerable<JobType>> GetAll();

        Task<JobType> GetById(string id);

        void Add(JobType item);

        void Update(JobType item);

        void Delete(JobType item);
    }
}
