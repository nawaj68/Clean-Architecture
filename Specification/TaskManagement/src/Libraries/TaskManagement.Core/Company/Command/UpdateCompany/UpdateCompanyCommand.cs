using System.Text.Json.Serialization;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Company.Command.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<VMCompany>
    {
        [JsonConstructor]
        public UpdateCompanyCommand(VMCompany company)
        {
            Id = company.Id;
            CompanyName = company.CompanyName;
            Address = company.Address;
            Owner = company.Owner;
        }
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Owner { get; set; }
    }
}
