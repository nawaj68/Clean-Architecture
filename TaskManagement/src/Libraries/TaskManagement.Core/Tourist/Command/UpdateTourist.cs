using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Tourist.Command
{
    public static class UpdateTourist 
    {
        public record UpdateTouristCommend(VMTourist vmtourist,int id) : IRequest<VMTourist>;

        public class UpdateTouristHandelar : IRequestHandler<UpdateTouristCommend, VMTourist>
        {
            private readonly ITouristRepository _touristrepo;

            public UpdateTouristHandelar(ITouristRepository touristrepo)
            {
                _touristrepo = touristrepo;
            }

            public async Task<VMTourist> Handle(UpdateTouristCommend request, CancellationToken cancellationToken)
            {
                var tourist = new TaskManagement.Models.Tourist
                {
                    Id = request.id,
                    Name = request.vmtourist.Name,
                    Email = request.vmtourist.Email,
                    PhoneNumber = request.vmtourist.PhoneNumber,
                    Age = request.vmtourist.Age,
                    JournyDate = request.vmtourist.JournyDate
                };
                return await _touristrepo.Update(request.id,tourist);
            }
        }
    }
}
