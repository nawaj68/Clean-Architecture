using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;

namespace TaskManagement.Core.Tourist.Command;

public static class DeleteTourist 
{
    public record DeleteTouristCommend(int id) : IRequest<VMTourist>;

    public class DeleteTouristHandelar : IRequestHandler<DeleteTouristCommend, VMTourist>
    {
        private readonly ITouristRepository _touristrepo;

        public DeleteTouristHandelar(ITouristRepository touristrepo)
        {
            _touristrepo = touristrepo;
        }

        public async Task<VMTourist> Handle(DeleteTouristCommend request, CancellationToken cancellationToken)
        {
            var _tourist = await _touristrepo.GetById(request.id);
            var tourist = new TaskManagement.Models.Tourist
            {
                Id = _tourist.Id,
                Name = _tourist.Name,
                Email = _tourist.Email,
                PhoneNumber = _tourist.Age,
                JournyDate = _tourist.JournyDate,
                Status = Shared.Enums.EntityStatus.Deleted,
            };
            return await _touristrepo.Update(request.id, tourist);
        }
    }
}

