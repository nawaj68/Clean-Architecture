using AutoMapper;
using Microsoft.EntityFrameworkCore;

using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;


namespace TaskManagement.Repositories.Concrete;

public class UsersRepository : RepositoryBase<Employee, VMEmployee, int>, IUserRepository
{

    /// <inheritdoc />
    public UsersRepository(IMapper mapper, TaskManagementContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<VMEmployee> GetByName(string name)
    {
        var data =await DbSet.FirstOrDefaultAsync(x => x.FirstName == name);
        return _mapper.Map<VMEmployee>(data);
    }
}