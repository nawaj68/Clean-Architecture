using FluentValidation;

namespace TaskManagement.Core.Company.Query.GetCompanyById
{
    public class GetCompanyByIdQueryValidator : AbstractValidator<GetCompanyByIdQuery>
    {
        public GetCompanyByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required");
        }
    }
}
