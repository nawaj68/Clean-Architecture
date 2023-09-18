using JetBrains.Annotations;
using TaskManagement.Infrastructure.Specifications;
using TaskManagement.Infrastructure.Specifications.Filters;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Core.Product.Query.GetProductWithPagination;

public class GetProductWithPaginationQuery : IRequest<QueryResult<PaginatedList<Service.Models.Product>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}
[UsedImplicitly]
public class GetProductWithPaginationQueryHandler : IRequestHandler<GetProductWithPaginationQuery, QueryResult<PaginatedList<Service.Models.Product>>>
{
    private readonly ICommonService<Models.Product, Service.Models.Product, int> _productRepository;

    public GetProductWithPaginationQueryHandler(ICommonService<Models.Product, Service.Models.Product, int> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<QueryResult<PaginatedList<Service.Models.Product>>> Handle(GetProductWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var spec = new PagingSpec<Models.Product>(BaseFilter.Instance,x=>x.ProductItems);
      
        var result = await _productRepository.List(spec, cancellationToken);

        if (result.Items.Any())
        {

            return new QueryResult<PaginatedList<Service.Models.Product>>(result);
        }
        return new QueryResult<PaginatedList<Service.Models.Product>>(result, QueryResultTypeEnum.Success);


    }

}
