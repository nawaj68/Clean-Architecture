using Microsoft.AspNetCore.Mvc;

using TaskManagement.Core.Employee.Query.GetEmployeeById;
using TaskManagement.Core.Employee.Query.GetUsersWithPagination;

using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Backend.Controllers;

public class UserController : ApiControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VMEmployee>> Get(int id)
    {
       return await Mediator.Send(new GetEmployeeByIdQuery(id));

    }
    [HttpGet]
    public async Task<ActionResult<PaginatedList<VMEmployee>>> GetTodoItemsWithPagination([FromQuery] GetUsersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}