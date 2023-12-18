using System.Collections.Generic;
using System.Threading.Tasks;
using JobTastic.Areas.Identity.Data;

namespace JobTastic.Repositories.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> GetById(string id);
    }
}
