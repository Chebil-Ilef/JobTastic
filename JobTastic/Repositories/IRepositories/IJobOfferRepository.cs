using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Repositories.IRepositories
{
    public interface IJobOfferRepository
    {
        Task<IList<JobOffer>> GetAll();

        Task<JobOffer> GetById(string id);

        void Add(JobOffer item);

        void Update(JobOffer item);

        void Delete(JobOffer item);
    }
}
