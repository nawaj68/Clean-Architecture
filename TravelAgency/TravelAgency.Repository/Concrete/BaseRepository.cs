using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure.Persistence;
using TravelAgency.Repository.Interface;
using TravelAgency.Shared;

namespace TravelAgency.Repository.Concrete;

public class BaseRepository<TEntity, T> : RepositoryBase<TEntity>, IRepository<TEntity, T>, IReadRepository<TEntity, T>
where TEntity : class, IEntity<T>, new()
where T : IEquatable<T>
{
    public BaseRepository(TravelAgenceContext dbContext) : base(dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> DbSet { get; set; }

}
