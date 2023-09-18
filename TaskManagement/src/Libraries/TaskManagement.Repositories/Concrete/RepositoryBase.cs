using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Shared;
using TaskManagement.Shared.Common.Mapping;
using TaskManagement.Shared.Common.Models;
using TaskManagement.Shared.Contracts;
using TaskManagement.Shared.Extensions;

namespace TaskManagement.Repositories.Concrete;

public abstract class RepositoryBase<TEntity,IModel,T>:IRepository<TEntity,IModel,T>
where TEntity : class,IEntity<T>,new()
where IModel :class,IVM<T>,new()
where T : IEquatable<T>
{
    protected readonly IMapper _mapper;
    private readonly DbContext _dbContext;

    protected RepositoryBase(IMapper mapper, DbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public DbSet<TEntity> DbSet { get; }

    /// <inheritdoc />
    public async Task<IModel> GetById(T id)
    {
        var data= await DbSet.FindAsync(id);
        return data.IfNotNull(_mapper.Map<IModel>);

    }

    /// <inheritdoc />
    public Task<PaginatedList<IModel>> List(int PageNumber,int PageSize)
    {
        return DbSet.ProjectTo<IModel>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(PageNumber, PageSize);
    }

    /// <inheritdoc />
    public Task<PaginatedList<IModel>> List( Expression<Func<TEntity, bool>> predicate,int PageNumber,int PageSize)
    {
        IQueryable<TEntity> query = DbSet;
        return query.Where(predicate).ProjectTo<IModel>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(PageNumber, PageSize);
    }

    /// <inheritdoc />
    public Task Delete(TEntity entity)
    {

        if (DbSet.Entry(entity).State == EntityState.Detached)
        {
            DbSet.Attach(entity);
        }
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task Delete(T id)
    {
        var entityToDelete = await DbSet.FindAsync(id);
        await entityToDelete.IfNotNull(Delete!);
    }

    /// <inheritdoc />
    public async Task<IModel> Update(T id, TEntity entity)
    {
        if(entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
           
        }
        var exit = await DbSet.FindAsync(id);
        if (exit != null)
        {
             DbSet.Entry(exit).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();

        }
        return _mapper.Map<IModel>(entity);

    }

    /// <inheritdoc />
    public async Task<IModel> Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<IModel>(entity);
    }

    /// <inheritdoc />
    public Task<bool> Save(TEntity entity)
    {
        throw new NotImplementedException();
    }
}