using JetBrains.Annotations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Infrastructure.Specifications;
using TravelAgency.Models;
using TravelAgency.Service.Model;
using TravelAgency.Shared.Common.Interface;
using TravelAgency.Shared.Common.Models;
using TravelAgency.Shared.Common.Result;

namespace TravelAgency.Core.TravelAgency.Query.GetTouristWithPagination;

public class GetTouristWithPaginationQuery : IRequest<QueryResult<PaginatedList<TouristVM>>>
{

    public int PageSize { get; init; } = 1;
    public int PageNumber { get; init; } = 10;
}
[UsedImplicitly]
public class GetTouristWithPaginationQueryHandler : IRequestHandler<GetTouristWithPaginationQuery, QueryResult<PaginatedList<TouristVM>>>
{
    private readonly ICommonService<Tourist,TouristVM,int> _touristservice;

    public GetTouristWithPaginationQueryHandler(ICommonService<Tourist,TouristVM, int> touristservice)
    {
        _touristservice = touristservice;
    }

    public async Task<QueryResult<PaginatedList<TouristVM>>> Handle(GetTouristWithPaginationQuery query, CancellationToken cancellationToken)
    {
        var spec = new PagingSpec<Tourist>(BaseFilter.Instance);
        var result = await _touristservice.List(spec, cancellationToken);
        if(result.Items.Any())
        {
            return new QueryResult<PaginatedList<TouristVM>>(result);
        }
        return new QueryResult<PaginatedList<TouristVM>>(result, QueryResultTypeEnum.Success);
    }
}