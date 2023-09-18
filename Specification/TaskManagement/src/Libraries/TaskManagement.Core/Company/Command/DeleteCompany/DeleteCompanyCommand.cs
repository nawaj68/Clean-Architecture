using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Company.Command.DeleteCompany
{
    public class DeleteCompanyCommand: IRequest
    {
        public DeleteCompanyCommand(int id)
        {

            Id = id;

        }
        public int Id { get; set; }
    }
}
