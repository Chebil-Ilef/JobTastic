using System.Threading.Tasks;

namespace JobTastic.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
