using MediatR;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Backend.Filters;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Backend.Controllers;


[ApiController]
[ApiExceptionFilter]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected async Task<ActionResult> HandleCommandAsync<T>(IRequest<CommandResult<T>> command)
    {
        var result = await Mediator.Send(command);

        return result.Type switch
        {
            CommandResultTypeEnum.InvalidInput => new BadRequestResult(),
            CommandResultTypeEnum.NotFound => new NotFoundResult(),
            CommandResultTypeEnum.Created => new CreatedResult("",result.Result),
            _ => new OkObjectResult(result.Result)
        } ; ;
    }


    protected async Task<ActionResult> HandleQueryAsync<T>(IRequest<QueryResult<T>> query)
    {
        var result = await Mediator.Send(query);

        return result.Type switch
        {
            QueryResultTypeEnum.InvalidInput => new BadRequestResult(),
            QueryResultTypeEnum.NotFound => new NotFoundResult(),
            _ => new OkObjectResult(result.Result)
        };
    }
}