using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Core.Tourist.Query.GetTouristById;

public class GetTouristByIdQueryValidator : AbstractValidator<GetTouristByIdQuery>
{

    public GetTouristByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
