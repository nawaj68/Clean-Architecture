using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Repositories.Interfaces;

namespace TaskManagement.Repositories.Concrete;

public class ProductRepository : TaskManagementRepositoryBase<Models.Product,  int>, IProductRepository
{
    public ProductRepository(TaskManagementContext dbContext) : base(dbContext)
    {
        
    }

    
}
