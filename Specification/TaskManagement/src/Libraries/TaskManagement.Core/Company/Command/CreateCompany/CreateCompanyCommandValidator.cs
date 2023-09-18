using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Company.Command.CreateCompany
{
    public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x=>x.CompanyName).NotEmpty().WithMessage("Company Name is Required");
            RuleFor(x=>x.Owner).NotEmpty().WithMessage("Owner Name is Required");
        }
    }
}
