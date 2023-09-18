using FluentValidation;

namespace TaskManagement.Core.Employee.Query.GetUsersWithPagination;

public class GetUsersWithPaginationQueryValidator:AbstractValidator<GetUsersWithPaginationQuery>
{
    public GetUsersWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).LessThan(1000);
       
    }
}