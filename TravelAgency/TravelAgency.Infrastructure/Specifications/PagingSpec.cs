using Ardalis.Specification;
using System.Linq.Expressions;

namespace TravelAgency.Infrastructure.Specifications;

public class PagingSpec<TEntity> : Specification<TEntity>,ISpecification<TEntity>
    where TEntity : class, Shared.IEntity<int>
{
    public PagingSpec(BaseFilter filter, Expression<Func<TEntity, object>> includeExp = null!)
    {
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                 .Take(PaginationHelper.CalculateTake(filter));
        if (includeExp != null)
        {
            Query.Include(includeExp);
        }

    }
}
