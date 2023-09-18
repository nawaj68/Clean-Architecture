using FluentValidation;

namespace TaskManagement.Core.Product.Query.Validator
{
    public class GetUserByIdQueryValidator :AbstractValidator<GetProductByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {

            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
