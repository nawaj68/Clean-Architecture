using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Contracts;
using Employee = TaskManagement.Service.Models.Employee;

namespace TaskManagement.Repositories.Interfaces;

public interface IUserRepository:IRepository<Models.Employee, int>
{
    //public Task<Employee> GetByName(string name);
}