using FluentValidation;

using JetBrains.Annotations;
using TaskManagement.Infrastructure.Specifications;
using TaskManagement.Infrastructure.Specifications.Filters;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Exceptions;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Common.Models;

using ValidationException = TaskManagement.Shared.Common.Exceptions.ValidationException;

namespace TaskManagement.Core.Employee.Query.GetUsersWithPagination;

public class GetUsersWithPaginationQuery : IRequest<QueryResult<PaginatedList<Service.Models.Employee>>>
{

	public int PageNumber { get; init; } = 1;
	public int PageSize { get; init; } = 10;
}

[UsedImplicitly]
public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, QueryResult<PaginatedList<Service.Models.Employee>>>
{
	private readonly ICommonService<Models.Employee,Service.Models.Employee,int> _userRepo;
    private readonly IValidator<GetUsersWithPaginationQuery> _validator;
    public GetUsersWithPaginationQueryHandler(IValidator<GetUsersWithPaginationQuery> validator, ICommonService<Models.Employee, Service.Models.Employee, int> userRepo)
    {
        _validator = validator;
        _userRepo = userRepo;
    }

    public async Task<QueryResult<PaginatedList<Service.Models.Employee>>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
	{
        var spec = new PagingSpec<Models.Employee>(BaseFilter.Instance);
		var employees= await _userRepo.List(spec, cancellationToken);


        var validate = await _validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid) throw new ValidationException(validate.Errors);

        ;
        return employees.Items.Any() ? new QueryResult<PaginatedList<Service.Models.Employee>>(employees) : new QueryResult<PaginatedList<Service.Models.Employee>>(employees, QueryResultTypeEnum.NotFound);
    }
}