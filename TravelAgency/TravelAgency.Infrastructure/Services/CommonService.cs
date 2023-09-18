using AutoMapper;
using TravelAgency.Shared;
using TravelAgency.Shared.Common.Interface;
using TravelAgency.Repository.Interface;
using TravelAgency.Shared.Common.Models;
using Ardalis.Specification;
using TravelAgency.Shared.Extensions;
using TravelAgency.Infrastructure.Persistence;

namespace TravelAgency.Infrastructure.Services;

public class CommonService<TEntity,IModel,T> : ICommonService<TEntity,IModel,T>
    where TEntity : class, Shared.IEntity<T>
    where T : IEquatable<T>
{
    private readonly IRepository<TEntity, T> _repository;
    private readonly IMapper _mapper;
   
    public CommonService(IRepository<TEntity, T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IModel> AddAsync(TEntity entity)
    {
        var result = await _repository.AddAsync(entity);

        return _mapper.Map<IModel>(result);

    }
    public Task Delete(TEntity entity)
    {
        return _repository.DeleteAsync(entity);
    }
    public async Task Delete(T id)
    {
        var entity = await _repository.GetByIdAsync(id);
        //HACK : Test 
        if (entity is not null)
            await _repository.DeleteAsync(entity);
    }
    public async Task<IEnumerable<IModel>> GetAll()
    {
        var result = await _repository.ListAsync();
        //TODO : throw exception 
        return _mapper.Map<IEnumerable<IModel>>(result);
    }

    public async Task<IModel> GetById(T id)
    {
        return _mapper.Map<IModel>(await _repository.GetByIdAsync(id));
    }
    public async Task<IModel> Update(T id, TEntity entity)
    {
        var temp = await _repository.GetByIdAsync(id);
        if (temp is not null)
        {
            entity.Copy(temp);
            await _repository.UpdateAsync(temp);
        }
        return _mapper.Map<IModel>(temp);
    }

    public async Task<PaginatedList<IModel>> List(ISpecification<TEntity> spec, CancellationToken cancellationToken)
    {

        var result = await _repository.ListAsync(spec, cancellationToken);

        return PaginatedList<IModel>.Create(_mapper.Map<List<IModel>>(result), spec.Skip, spec.Take);
    }
}
