using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.Repositories.Interfaces
{
    public interface ICompanyRepository : IRepository<Companies, int>
    {
    }
}
