using TaskManagement.Service.Models;
using FluentValidation;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Core.Company.Query.GetCompanyById;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Core.Handlers
{
    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, VMCompany>
    {
        private readonly ICommonService<Models.Companies,Service.Models.VMCompany,int> _companyRepository;
        private readonly IValidator<GetCompanyByIdQuery> _validator;
        public GetCompanyByIdQueryHandler(IValidator<GetCompanyByIdQuery> validator, ICommonService<Models.Companies, VMCompany, int> companyRepository)
        {
            _validator = validator;
            _companyRepository = companyRepository;
        }

        public async Task<VMCompany> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await _companyRepository.GetById(request.Id);
            }
            throw new ValidationException(validationResult.Errors);
        }
    }
}
