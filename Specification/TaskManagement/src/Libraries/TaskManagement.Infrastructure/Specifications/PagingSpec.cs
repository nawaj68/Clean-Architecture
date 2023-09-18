
using Ardalis.Specification;
using System.Linq.Expressions;
using TaskManagement.Infrastructure.Specifications.Filters;

namespace TaskManagement.Infrastructure.Specifications;

public class PagingSpec<TEntity> : Specification<TEntity>, ISpecification<TEntity>
    where TEntity : class, Shared.IEntity<int>
{
    public PagingSpec(BaseFilter filter,Expression<Func<TEntity,object>> includeExp=null!)
    {
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                 .Take(PaginationHelper.CalculateTake(filter));
       if(includeExp != null)
        {
            Query.Include(includeExp);
        }

    }

}
