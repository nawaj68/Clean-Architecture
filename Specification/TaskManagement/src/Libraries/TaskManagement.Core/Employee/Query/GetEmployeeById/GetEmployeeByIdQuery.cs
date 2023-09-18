using System.Text.Json.Serialization;
using FluentValidation;
using JetBrains.Annotations;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Common.Models;
using ValidationException = TaskManagement.Shared.Common.Exceptions.ValidationException;

namespace TaskManagement.Core.Employee.Query.GetEmployeeById;

public class GetEmployeeByIdQuery : IRequest<QueryResult<Service.Models.Employee>>
{
    [JsonConstructor]
    public GetEmployeeByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

    [UsedImplicitly]
    public class GetUserByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, QueryResult<Service.Models.Employee>>
    {
        private readonly ICommonService<Models.Employee,Service.Models.Employee,int> _userRepository;
        private readonly IValidator<GetEmployeeByIdQuery> _validator;

        public GetUserByIdQueryHandler(IValidator<GetEmployeeByIdQuery> validator, ICommonService<Models.Employee, Service.Models.Employee, int> userRepository)
        {

            _validator = validator;
            _userRepository = userRepository;
        }

        public async Task<QueryResult<Service.Models.Employee>> Handle(GetEmployeeByIdQuery request,
            CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid) throw new ValidationException(validate.Errors);

            var employee = await _userRepository.GetById(request.Id);
            ;
            return employee switch
            {
                null => new QueryResult<Service.Models.Employee>(null, QueryResultTypeEnum.NotFound),
                _ => new QueryResult<Service.Models.Employee>(employee, QueryResultTypeEnum.Success)
            };

        }

    }
}