using JetBrains.Annotations;

using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Core.Employee.Query.GetUsersWithPagination;

public class GetUsersWithPaginationQuery : IRequest<PaginatedList<VMEmployee>>
{

	public int PageNumber { get; init; } = 1;
	public int PageSize { get; init; } = 10;
}

[UsedImplicitly]
public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<VMEmployee>>
{
	private readonly IUserRepository _userRepo;

	public GetUsersWithPaginationQueryHandler(IUserRepository userRepo)
	{
		_userRepo = userRepo;
	}

	public async Task<PaginatedList<VMEmployee>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
	{
		return await _userRepo.List(request.PageNumber, request.PageSize);
	}
}