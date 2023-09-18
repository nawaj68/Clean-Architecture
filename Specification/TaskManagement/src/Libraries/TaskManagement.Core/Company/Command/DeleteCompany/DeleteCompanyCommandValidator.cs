using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Company.Command.DeleteCompany
{
    public class DeleteCompanyCommandValidator:AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
