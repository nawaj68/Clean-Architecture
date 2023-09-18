using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Core.Tourist.Query.GetTouristWithPagination
{
    public class GetTouristWithPaginationQuery : IRequest<PaginatedList<VMTourist>>
    {

        public int PageSize { get; init; } = 1;
        public int PageNumber { get; init; } = 10;
    }

    [UsedImplicitly]
    public class GetTouristWithPaginationQueryHandler : IRequestHandler<GetTouristWithPaginationQuery, PaginatedList<VMTourist>> 
    {
        private readonly ITouristRepository _touristrepo;

        public GetTouristWithPaginationQueryHandler(ITouristRepository touristrepo)
        {
            _touristrepo = touristrepo;
        }

        public async Task<PaginatedList<VMTourist>> Handle(GetTouristWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _touristrepo.List(query.PageSize, query.PageNumber);
        }
    }
}
