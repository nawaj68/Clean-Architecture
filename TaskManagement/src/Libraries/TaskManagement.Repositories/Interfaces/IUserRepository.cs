using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.Repositories.Interfaces;

public interface IUserRepository:IRepository<Employee,VMEmployee,int>
{
    public Task<VMEmployee> GetByName(string name);
}