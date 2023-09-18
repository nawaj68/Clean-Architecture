using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Core.Product.Command;

public class UpdateProduct
{
    public record UpdateProductCommand(Service.Models.Product _product,int id) : IRequest<Service.Models.Product> { }
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Service.Models.Product>
    {
        private readonly ICommonService<Models.Product,Service.Models.Product,int> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IMapper mapper, ICommonService<Models.Product, Service.Models.Product, int> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Service.Models.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
          
            var data=_mapper.Map<Models.Product>(request._product);
            return await _productRepository.Update(request.id, data);
        }
    }
}
