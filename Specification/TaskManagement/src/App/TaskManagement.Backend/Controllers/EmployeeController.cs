using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TaskManagement.Core.Employee.Query.GetEmployeeById;
using TaskManagement.Core.Employee.Query.GetUsersWithPagination;

using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Backend.Controllers;
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EmployeeController : ApiControllerBase
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employee>> Get(int id)
    {
        return await HandleQueryAsync(new GetEmployeeByIdQuery(id));

    }
    [HttpGet]
    [ApiVersion("2")]
    [ApiVersion("1")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ApiExplorerSettings(GroupName = "v2")]
    public async Task<ActionResult<PaginatedList<Employee>>> GetTodoItemsWithPagination([FromQuery] GetUsersWithPaginationQuery query)
    {
        return await HandleQueryAsync(query);
    }
}