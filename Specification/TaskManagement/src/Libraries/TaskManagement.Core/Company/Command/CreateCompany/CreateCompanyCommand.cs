using System.Text.Json.Serialization;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Company.Command.CreateCompany
{
    public class CreateCompanyCommand: IRequest<VMCompany>
    {
        [JsonConstructor]
        public CreateCompanyCommand(VMCompany company) 
        {
            CompanyName = company.CompanyName;
            Address = company.Address;
            Owner = company.Owner;
        }
        
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Owner { get; set;}
    }
}
