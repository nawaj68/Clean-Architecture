using AutoMapper;
using MediatR;
using TravelAgency.Models;
using TravelAgency.Service.Model;
using TravelAgency.Shared.Common.Interface;

namespace TravelAgency.Core.TravelAgency.Command;

public static class DeleteTouristCommand
{
    public record DeleteTourist(int Id) : IRequest<TouristVM>;

    public class DeleteToristandelar: IRequestHandler<DeleteTourist, TouristVM>
    {
        private readonly ICommonService<Tourist, TouristVM, int> _touristservice;
        private readonly IMapper _mapper;

        public DeleteToristandelar( ICommonService<Tourist,TouristVM,int> touristservice,IMapper mapper)
        {
                _mapper = mapper;
               _touristservice = touristservice;
        }
        public async Task<TouristVM> Handle(DeleteTourist command, CancellationToken cancellationToken)
        {
            var _tourist = await _touristservice.GetById(command.Id);
            var tourist = _mapper.Map<Tourist>(_tourist);
            tourist.Status = Shared.Enums.EntityStatus.Deleted;
            return await _touristservice.Update(command.Id,tourist);    
        }
    }
}
