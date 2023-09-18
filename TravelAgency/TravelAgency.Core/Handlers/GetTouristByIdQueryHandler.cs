using FluentValidation;
using JetBrains.Annotations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Core.TravelAgency.Query.GetTouristByID;
using TravelAgency.Shared.Common.Interface;
using TravelAgency.Shared.Common.Result;

namespace TravelAgency.Core.Handlers;

[UsedImplicitly]
public class GetTouristByIdQueryHandler : IRequestHandler<GetTouristByIdQuery, QueryResult<Service.Model.TouristVM>>
{
    private readonly ICommonService<Models.Tourist, Service.Model.TouristVM, int> _commonService;
    private readonly IValidator<GetTouristByIdQuery> _validator;

    public GetTouristByIdQueryHandler(ICommonService<Models.Tourist, Service.Model.TouristVM, int> commonService, IValidator<GetTouristByIdQuery> validator)
    {
        _commonService = commonService;
        _validator = validator;
    }

    public async Task<QueryResult<Service.Model.TouristVM>> Handle(GetTouristByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var tourist = await _commonService.GetById(request.Id);

        if (tourist is null)
            return new QueryResult<Service.Model.TouristVM>(null, QueryResultTypeEnum.NotFound);

        return new QueryResult<Service.Model.TouristVM>(tourist, QueryResultTypeEnum.Success);
    }
}
