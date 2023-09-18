using Ardalis.Specification;
using TravelAgency.Shared.Common.Models;

namespace TravelAgency.Shared.Common.Interface;

public interface ICommonService<TEntity, IModel,T>
    where T : IEquatable<T>
{
    public Task<IModel> GetById(T id);
    public Task<PaginatedList<IModel>> List(ISpecification<TEntity> spec, CancellationToken cancellationToken);
    public Task Delete(TEntity entity);
    public Task Delete(T id);
    public Task<IEnumerable<IModel>> GetAll();
    public Task<IModel> Update(T id, TEntity entity);

    public Task<IModel> AddAsync(TEntity entity);
}
