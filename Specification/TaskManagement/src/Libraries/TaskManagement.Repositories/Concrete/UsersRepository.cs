using AutoMapper;
using Microsoft.EntityFrameworkCore;

using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using Employee = TaskManagement.Service.Models.Employee;


namespace TaskManagement.Repositories.Concrete;

public class UsersRepository : TaskManagementRepositoryBase<Models.Employee,  int>, IUserRepository
{

    /// <inheritdoc />
    public UsersRepository(IMapper mapper, TaskManagementContext dbContext) : base(dbContext)
    {
    }
}