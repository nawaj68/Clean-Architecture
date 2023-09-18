using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.Repositories.Interfaces
{
    public interface ITouristRepository : IRepository<Tourist,VMTourist,int>
    {
        public Task <VMTourist> GetByName (string name);
    }
}
