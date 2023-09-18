using TaskManagement.Service.Models;
using System.Text.Json.Serialization;
using TaskManagement.Models;
using TaskManagement.Repositories.Concrete;

namespace TaskManagement.Core.Company.Query.GetCompanyById
{
    public class GetCompanyByIdQuery:IRequest<VMCompany>
    {
        [JsonConstructor]
        public GetCompanyByIdQuery(int id)
        {

            Id = id;

        }
        public int Id { get; set; }
    }
}
