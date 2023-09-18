using FluentValidation;
using TaskManagement.Core.Company.Command.UpdateCompany;
using TaskManagement.Models;
using TaskManagement.Repositories.Concrete;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Core.Handlers
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, VMCompany>
    {
        private readonly ICommonService<Models.Companies, Service.Models.VMCompany, int> _companyRepository;
        private readonly IValidator<UpdateCompanyCommand> _validator;
        public UpdateCompanyCommandHandler(ICommonService<Companies, VMCompany, int> companyRepository, IValidator<UpdateCompanyCommand> validator)
        {
            _companyRepository = companyRepository;
            _validator = validator;
        }

        public async Task<VMCompany> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                Companies com = new Companies()
                {
                    CompanyName = request.CompanyName,
                    Address = request.Address,
                    Owner = request.Owner,
                    Status = EntityStatus.Updated,
                    LastModified = DateTimeOffset.Now,
                    LastModifiedBy = "1"
                };

                return await _companyRepository.Update(request.Id, com);
            }
            throw new ValidationException(validationResult.Errors);
        }
    }
}
