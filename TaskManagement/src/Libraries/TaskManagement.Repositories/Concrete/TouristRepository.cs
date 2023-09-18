using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Repositories.Concrete
{
    public class TouristRepository : RepositoryBase<Tourist, VMTourist,int>, ITouristRepository
    {


        public TouristRepository (IMapper mapper, TaskManagementContext dbcontext)  : base(mapper, dbcontext)
        {

        }

        public async Task<VMTourist> GetByName(string name)
        {
            var data = await DbSet.FirstOrDefaultAsync(x => x.Name == name);
            return _mapper.Map<VMTourist>(data);
        }
    }
}
