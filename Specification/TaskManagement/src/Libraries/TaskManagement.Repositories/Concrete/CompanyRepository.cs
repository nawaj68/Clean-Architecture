using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Repositories.Concrete
{
    public class CompanyRepository : RepositoryBase<Companies, VMCompany, int>, ICompanyRepository
    {
        public CompanyRepository(IMapper mapper, TaskManagementContext dbContext) : base(mapper, dbContext)
        {
        }
    }
}
