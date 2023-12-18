using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Models;

namespace JobTastic.Services.IServices
{
    public interface IJobOfferService
    {
        Task<IList<JobOffer>> GetAllOffers();

        Task<JobOffer> GetOfferById(string id);

        Task<bool> Add(JobOffer item);

        Task<bool> Edit(JobOffer item);

        Task<bool> Delete(JobOffer offer);

        Task<IEnumerable<JobOffer>> GetMostPopularOffers();

        Task<IEnumerable<JobOffer>> GetOffersContainingPhrase(string phrase);

        Task<bool> CanUserEditOffer(string userId, string offerId);

        Task<bool> IncreaseOfferViews(JobOffer offer);
    }
}
