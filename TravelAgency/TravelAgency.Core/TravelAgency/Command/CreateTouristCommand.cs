using AutoMapper;
using MediatR;
using TravelAgency.Models;
using TravelAgency.Service.Model;
using TravelAgency.Shared.Common.Interface;

namespace TravelAgency.Core.TravelAgency.Command;

public static class CreateTouristCommand
{
    public record CreateTourist(TouristVM touristVM) : IRequest<TouristVM>;

    public class CreateTouristHandelar : IRequestHandler<CreateTourist, TouristVM>
    {
        private readonly ICommonService<Tourist, TouristVM, int> _touristservice;
        private readonly IMapper _mapper;

        public CreateTouristHandelar(ICommonService<Tourist,TouristVM,int> touristService, IMapper mapper)
        {
                _touristservice = touristService;
                _mapper = mapper;   
        }
        public async Task<TouristVM> Handle(CreateTourist request, CancellationToken cancellationtoken)
        {
            var tourist = _mapper.Map<Tourist>(request.touristVM);
            return await _touristservice.AddAsync(tourist);
        }
    }
}
