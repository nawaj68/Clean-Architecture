using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Tourist.Command
{
    public static class CreateTourist
    {
        public record CreateTouristCommand(VMTourist vmtourist) : IRequest<VMTourist>;

        public class CreateTouriestHandelar : IRequestHandler<CreateTouristCommand, VMTourist>
        {
            private readonly ITouristRepository _touristrepo;

            public CreateTouriestHandelar(ITouristRepository touristrepo)
            {
                _touristrepo = touristrepo;
            }

            public async Task<VMTourist> Handle(CreateTouristCommand request, CancellationToken cancellationToken)
            {
                var tourist = new TaskManagement.Models.Tourist
                {
                    Name=request.vmtourist.Name,
                    Email= request.vmtourist.Email,
                    PhoneNumber = request.vmtourist.PhoneNumber,
                    Age= request.vmtourist.Age,
                    JournyDate = request.vmtourist.JournyDate
                };
                return await _touristrepo.Add(tourist);
            }
        }
    }
}
