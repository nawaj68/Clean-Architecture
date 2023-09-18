using FluentValidation;

using JetBrains.Annotations;

using TaskManagement.Core.Employee.Query.GetEmployeeById;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;


namespace TaskManagement.Core.Handlers;
[UsedImplicitly]
public class GetUserByIdQueryHandler:IRequestHandler<GetEmployeeByIdQuery, VMEmployee>
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<GetEmployeeByIdQuery> _validator;
	public GetUserByIdQueryHandler(IUserRepository userRepository, IValidator<GetEmployeeByIdQuery> validator)
	{
		_userRepository = userRepository;
		_validator = validator;
	}

	/// <inheritdoc />
	public async Task<VMEmployee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
		var validastionResult=await _validator.ValidateAsync(request, cancellationToken);
		if (validastionResult.IsValid)
		{
			return await _userRepository.GetById(request.Id);
		}
		throw new ValidationException(validastionResult.Errors);
    }
}