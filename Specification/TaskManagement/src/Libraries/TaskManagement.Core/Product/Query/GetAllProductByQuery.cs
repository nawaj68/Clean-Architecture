using AutoMapper;
using TaskManagement.Repositories.Interfaces;
using System.Threading.Tasks;
using TaskManagement.Service.Models;
using System.Collections.Generic;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Core.Product.Query;

public record GetAllProductByQuery:IRequest<IEnumerable<Service.Models.Product>>
{
}
public class GetAllProductByQueryHandler : IRequestHandler<GetAllProductByQuery, IEnumerable<Service.Models.Product>>
{
    private readonly ICommonService<Models.Product,Service.Models.Product,int> _productRepository;
    public GetAllProductByQueryHandler(ICommonService<Models.Product, Service.Models.Product, int> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Service.Models.Product>> Handle(GetAllProductByQuery request, CancellationToken cancellationToken)
    {
        //var data = await _productRepository.GetAll();
        // var mappedData = _mapper.Map<IEnumerable<VMProduct>>(data);
        // return mappedData;

        var data = await _productRepository.GetAll();
        return data;

        //var data = await _productRepository.GetAll();
        //var mappedData = _mapper.Map<IEnumerable<VMProduct>>(data);
        //return mappedData;
    }
}

