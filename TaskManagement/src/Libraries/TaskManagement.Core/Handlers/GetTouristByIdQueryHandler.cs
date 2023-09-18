using FluentValidation;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Tourist.Query.GetTouristById;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Handlers;

[UsedImplicitly]
public class GetTouristByIdQueryHandler : IRequestHandler<GetTouristByIdQuery, VMTourist>
{
    private readonly ITouristRepository _touristrepo;
    private readonly IValidator<GetTouristByIdQuery> _validator;


    public GetTouristByIdQueryHandler(ITouristRepository touristrepo, IValidator<GetTouristByIdQuery> validator)
    {
        _touristrepo = touristrepo;
        _validator = validator;
    }
    public async Task<VMTourist> Handle(GetTouristByIdQuery query, CancellationToken cancellationToken)
    {
        var ValidationResult= await _validator.ValidateAsync(query, cancellationToken);

    if(ValidationResult.IsValid)
        {
            return await _touristrepo.GetById(query.Id);
        }
        throw new ValidationException(ValidationResult.Errors);
    }
}
