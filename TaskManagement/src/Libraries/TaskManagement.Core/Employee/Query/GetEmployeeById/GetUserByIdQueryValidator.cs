using FluentValidation;

namespace TaskManagement.Core.Employee.Query.GetEmployeeById;

public class GetUserByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{

	public GetUserByIdQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
	}
}