using Ardalis.Specification;

namespace TravelAgency.Repository.Interface;

public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity>
        where TEntity : class, Shared.IEntity<TKey>
        where TKey : IEquatable<TKey>
{

}

/// <inheritdoc/>
public interface IReadRepository<TEntity, TKey> : IReadRepositoryBase<TEntity>
        where TEntity : class, Shared.IEntity<TKey>
        where TKey : IEquatable<TKey>
{

}