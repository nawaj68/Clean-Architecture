using FluentValidation;
using TaskManagement.Core.Company.Command.CreateCompany;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Core.Handlers
{
    internal class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, VMCompany>
    {
        private readonly ICommonService<Models.Companies,Service.Models.VMCompany,int> _companyRepository;
        private readonly IValidator<CreateCompanyCommand> _validator;
        public CreateCompanyCommandHandler(IValidator<CreateCompanyCommand> validator, ICommonService<Companies, VMCompany, int> companyRepository)
        {
            _validator = validator;
            _companyRepository = companyRepository;
        }



        public async Task<VMCompany> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                Companies com = new Companies() {
                    CompanyName = request.CompanyName,
                    Address = request.Address,
                    Owner = request.Owner,
                    Created = DateTimeOffset.Now,
                    CreatedBy = "1",
                    Status = EntityStatus.Created
                };
                
                return await _companyRepository.AddAsync(com);
            }
            throw new ValidationException(validationResult.Errors);
        }
    }
}
