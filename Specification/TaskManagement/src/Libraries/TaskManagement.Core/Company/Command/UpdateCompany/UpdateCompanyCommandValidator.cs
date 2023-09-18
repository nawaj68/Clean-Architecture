using FluentValidation;

namespace TaskManagement.Core.Company.Command.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company Name is Required");
            RuleFor(x => x.Owner).NotEmpty().WithMessage("Owner Name is Required");
        }
    }
}
