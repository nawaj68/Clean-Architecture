using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Tourist.Command;
using TaskManagement.Core.Tourist.Query.GetTouristById;
using TaskManagement.Core.Tourist.Query.GetTouristWithPagination;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Backend.Controllers;


public class TouristController : ApiControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VMTourist>> Get(int id)
    {
        return await Mediator.Send(new GetTouristByIdQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<VMTourist>>> GetToDoTuristWithPagination([FromQuery] GetTouristWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<VMTourist>> CreateTourist([FromBody] VMTourist vmtourist)
    {
        return await Mediator.Send(new CreateTourist.CreateTouristCommand(vmtourist));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<VMTourist>> UpdateTourist([FromBody] VMTourist vmtourist, int id)
    {
        return await Mediator.Send(new UpdateTourist.UpdateTouristCommend(vmtourist, id));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VMTourist>> DeleteTourist(int id)
    {
        return await Mediator.Send(new DeleteTourist.DeleteTouristCommend(id));
    }
}
