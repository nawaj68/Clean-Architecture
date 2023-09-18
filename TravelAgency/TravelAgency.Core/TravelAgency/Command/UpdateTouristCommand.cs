using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgency.Service.Model;
using TravelAgency.Shared.Common.Interface;

namespace TravelAgency.Core.TravelAgency.Command;

public static class UpdateTouristCommand
{
    public record UpdateTourist(TouristVM touristvm, int id) : IRequest<TouristVM>;

    //public class UpdateTourist : IRequest<TouristVM>
    //{
    //    public UpdateTourist(int id, TouristVM touristVM)
    //    {
    //        Id = id;
    //        TouristVM = touristVM;
    //    }

    //    public int Id { get; set; }
    //   public TouristVM TouristVM { get; set; }
    //}

    public class UpdateTouristHandelar : IRequestHandler<UpdateTourist, TouristVM>
    {
        private readonly ICommonService<Tourist, TouristVM, int> _touristservice;
        private readonly IMapper _mapper;

        public UpdateTouristHandelar(ICommonService<Tourist, TouristVM, int> touristservice, IMapper mapper)
        {
            _touristservice = touristservice;
            _mapper = mapper;
        }
        public async Task<TouristVM> Handle(UpdateTourist request, CancellationToken cancellationToken)
        {
            var tourist = _mapper.Map<Tourist>(request.touristvm);
            return await _touristservice.Update(request.id, tourist);
        }
    }
}
