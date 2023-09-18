using Microsoft.AspNetCore.Mvc;
using TravelAgency.Core.TravelAgency.Command;
using TravelAgency.Core.TravelAgency.Query.GetTouristByID;
using TravelAgency.Core.TravelAgency.Query.GetTouristWithPagination;
using TravelAgency.Service.Model;

namespace TravelAgencyBackend.Controllers;

public class TouristController : ApiControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TouristVM>> Get(int id)
    {
        return await HandleQueryAsync(new GetTouristByIdQuery(id));
    }

    [HttpGet]
    public async Task<ActionResult> GetTouristByPagination([FromQuery] GetTouristWithPaginationQuery query)
    {
        return await HandleQueryAsync(query);
    }

    [HttpPost]
    public async Task<ActionResult<TouristVM>> CreateTourist([FromBody] TouristVM touristVM)
    {
        return await Mediator.Send(new CreateTouristCommand.CreateTourist(touristVM));
    }
   
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateTourist(int id,[FromBody] TouristVM touristVM)
    {
        return Ok(await Mediator.Send(new UpdateTouristCommand.UpdateTourist (touristVM,id)));
    }
    [HttpDelete]
    public async Task<ActionResult<TouristVM>> DeleteTourist (int id)
    {
        return await Mediator.Send(new DeleteTouristCommand.DeleteTourist (id));
    }
}
