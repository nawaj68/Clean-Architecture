using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure.Persistence;
using TaskManagement.Shared;
using TaskManagement.Shared.Contracts;

namespace TaskManagement.Repositories.Concrete;
/// <inheritdoc/>

public  class TaskManagementRepositoryBase<TEntity, T> : RepositoryBase<TEntity>, IRepository<TEntity, T>, IReadRepository<TEntity, T>
where TEntity : class, IEntity<T>, new()
where T : IEquatable<T>
{
    public TaskManagementRepositoryBase(TaskManagementContext dbContext) : base(dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
    }

    public DbSet<TEntity> DbSet { get; }


    //protected RepositoryBase(IMapper mapper, DbContext dbContext)
    //{
    //    _mapper = mapper;
    //    _dbcontext = dbContext;
    //    DbSet = dbContext.Set<TEntity>();
    //}

    //public DbSet<TEntity> DbSet { get; }

    ///// <inheritdoc />
    //public async Task<IModel> GetById(T id)
    //{
    //    var data= await DbSet.FindAsync(id);
    //    return data.IfNotNull(_mapper.Map<IModel>);

    //}

    ///// <inheritdoc />
    //public Task<PaginatedList<IModel>> List(int PageNumber,int PageSize)
    //{
    //    return DbSet.ProjectTo<IModel>(_mapper.ConfigurationProvider)
    //        .PaginatedListAsync(PageNumber, PageSize);
    //}

    ///// <inheritdoc />
    //public Task<PaginatedList<IModel>> List( Expression<Func<TEntity, bool>> predicate,int PageNumber,int PageSize)
    //{
    //    IQueryable<TEntity> query = DbSet;
    //    return query.Where(predicate).ProjectTo<IModel>(_mapper.ConfigurationProvider)
    //        .PaginatedListAsync(PageNumber, PageSize);
    //}

    ///// <inheritdoc />
    //public Task Delete(TEntity entity)
    //{

    //    if (DbSet.Entry(entity).State == EntityState.Detached)
    //    {
    //        DbSet.Attach(entity);
    //    }
    //    DbSet.Remove(entity);
    //    return Task.CompletedTask;
    //}

    ///// <inheritdoc />
    //public async Task Delete(T id)
    //{

    //    var entityToDelete = await DbSet.FindAsync(id);
    //    if (entityToDelete != null)
    //    {
    //        DbSet.Remove(entityToDelete);
    //        await _dbcontext.SaveChangesAsync();
    //    }
    //}

    ////Entity =VM,
    //  //exit=Models/database
    //  // exit < entity

    ///// <inheritdoc />
    //public async Task<IModel> Update(T id, TEntity entity)
    //{
    //    if (entity == null)
    //    {
    //        throw new ArgumentNullException("entity");
    //    }
    //    var exist = await DbSet.FindAsync(id);
    //    if (exist != null)
    //    {
    //        DbSet.Entry(exist).CurrentValues.SetValues(entity);
    //        _dbcontext.SaveChanges();
    //    }
    //    return _mapper.Map<IModel>(entity);
    //}

    ///// <inheritdoc />
    //public async Task<IModel> Add(TEntity entity)
    //{

    //    await DbSet.AddAsync(entity);
    //    await _dbcontext.SaveChangesAsync();
    //    return _mapper.Map<IModel>(entity);
    //}

    ///// <inheritdoc />
    //public async Task<bool> Save(TEntity entity)
    //{
    //    if (DbSet.Entry(entity).State == EntityState.Detached)
    //    {
    //        DbSet.Attach(entity);
    //    }
    //    DbSet.Entry(entity).State = EntityState.Modified;
    //    await _dbcontext.SaveChangesAsync();
    //    return true;

    //}

    //public Task<IEnumerable<IModel>> GetAll()
    //{
    //    var data = DbSet.AsEnumerable();
    //    var models = _mapper.Map<IEnumerable<IModel>>(data);
    //    return Task.FromResult(models);
    //}
}