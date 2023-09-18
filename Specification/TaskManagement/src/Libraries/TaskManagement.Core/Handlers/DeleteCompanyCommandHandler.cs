using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Company.Command.DeleteCompany;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Core.Handlers
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly ICommonService<Models.Companies,Service.Models.VMCompany,int> _companyRepository;
        private readonly IValidator<DeleteCompanyCommand> _validator;
        public DeleteCompanyCommandHandler(IValidator<DeleteCompanyCommand> validator, ICommonService<Models.Companies, VMCompany, int> companyRepository)
        {

            _validator = validator;
            _companyRepository = companyRepository;
        }
        public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                await _companyRepository.Delete(request.Id);
            }
        }
    }
}
