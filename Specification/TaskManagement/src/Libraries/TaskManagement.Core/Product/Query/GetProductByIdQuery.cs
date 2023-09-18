using FluentValidation;
using JetBrains.Annotations;
using System.Text.Json.Serialization;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Core.Product.Query;

public class GetProductByIdQuery: IRequest<QueryResult<Service.Models.Product>>
{
    [JsonConstructor]
    public GetProductByIdQuery(int id )
    {
        Id = id;
    }
    public int  Id { get; set; }
}


[UsedImplicitly]
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, QueryResult<Service.Models.Product>>
{
    private readonly ICommonService<Models.Product,Service.Models.Product,int> _productRepository;
    private readonly IValidator<GetProductByIdQuery> _validator;

    public GetProductByIdQueryHandler(IValidator<GetProductByIdQuery> validator, ICommonService<Models.Product, Service.Models.Product, int> productRepository)
    {
        _validator = validator;
        _productRepository = productRepository;
    }

    public async Task<QueryResult<Service.Models.Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult= await _validator.ValidateAsync(request, cancellationToken);
        if(!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        var product=await _productRepository.GetById(request.Id);

        if(product is null)
        {
            return new QueryResult<Service.Models.Product>(null, QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<Service.Models.Product>(product, QueryResultTypeEnum.Success);
    }
}

