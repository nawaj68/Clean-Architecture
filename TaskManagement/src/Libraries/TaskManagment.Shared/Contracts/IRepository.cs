using System.Linq.Expressions;

using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Shared.Contracts;

public interface IRepository<TEntity,IModel,in T>
    where TEntity : class,IEntity<T>,new()
    where IModel :class,IVM<T>,new()
    where T : IEquatable<T>
{
    public Task<IModel> GetById(T id);
    //public Task<IModel> GetByName(string name);
    public Task<PaginatedList<IModel>> List(int PageNumber,int PageSize);
    public Task<PaginatedList<IModel>> List(Expression<Func<TEntity, bool>> predicate,int PageNumber,int PageSize);

    public Task Delete(TEntity entity);
    public Task Delete(T id);

    public Task<IModel> Update(T id,TEntity entity);

    public Task<IModel> Add(TEntity entity);

    public Task <bool> Save(TEntity entity);
}

