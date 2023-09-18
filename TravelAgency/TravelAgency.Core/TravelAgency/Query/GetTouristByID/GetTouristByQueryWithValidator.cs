using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Service.Model;

namespace TravelAgency.Core.TravelAgency.Query.GetTouristByID;

public class GetTouristByQueryWithValidator : AbstractValidator<GetTouristByIdQuery>
{
    public GetTouristByQueryWithValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
