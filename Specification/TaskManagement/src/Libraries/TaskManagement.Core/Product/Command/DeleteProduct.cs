using Microsoft.AspNetCore.Http.HttpResults;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;

namespace TaskManagement.Core.Product.Command;

public class DeleteProduct
{
    public record DeleteProductCommand(int id) : IRequest<Service.Models.Product> { }
    public class DeleteProductHanlder : IRequestHandler<DeleteProductCommand, Service.Models.Product>
    {
        private readonly ICommonService<Models.Product,Service.Models.Product,int> _productRepository;
        public DeleteProductHanlder(ICommonService<Models.Product, Service.Models.Product, int> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Service.Models.Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            
                await _productRepository.Delete(request.id);
            return new Service.Models.Product();
        }
    }
}
