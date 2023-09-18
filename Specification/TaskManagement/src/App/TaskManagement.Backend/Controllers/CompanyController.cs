using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using TaskManagement.Core.Company.Command.CreateCompany;
using TaskManagement.Core.Company.Command.DeleteCompany;
using TaskManagement.Core.Company.Command.UpdateCompany;
using TaskManagement.Core.Company.Query.GetCompanyById;
using TaskManagement.Service.Models;

namespace TaskManagement.Backend.Controllers
{
    /// <summary>
    /// Company Crude Operations
    /// </summary>
    /// <seealso cref="TaskManagement.Backend.Controllers.ApiControllerBase" />
    [ApiController]
    public class CompanyController : ApiControllerBase
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VMCompany>> Get(int id)
        {
            return await Mediator.Send(new GetCompanyByIdQuery(id));
        }
        /// <summary>
        /// Creates the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<VMCompany>> Create(VMCompany company)
        {
            return await Mediator.Send(new CreateCompanyCommand(company));
        }
        /// <summary>
        /// Updates the specified company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<VMCompany>> Update(VMCompany company)
        {
            return await Mediator.Send(new UpdateCompanyCommand(company));
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete]
        public async Task Delete(int id)
        {
            await Mediator.Send(new DeleteCompanyCommand(id));
        }
    }
}
