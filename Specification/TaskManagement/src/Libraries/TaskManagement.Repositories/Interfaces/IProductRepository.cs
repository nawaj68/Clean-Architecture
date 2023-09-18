using Ardalis.Specification;
using TaskManagement.Models;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.Repositories.Interfaces;

public interface IProductRepository:IRepository<Models.Product,int>
{
   
}

