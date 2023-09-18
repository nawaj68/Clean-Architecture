using AutoMapper;
using FluentValidation;
using System.Text.Json.Serialization;
using TaskManagement.Models;
using TaskManagement.Repositories.Interfaces;
using TaskManagement.Service.Models;
using TaskManagement.Shared.Common.Interfaces;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Core.Product.Command;

public class CreateProduct
{
    public record CreateProductCommand(Service.Models.Product Product) : IRequest<CommandResult<Service.Models.Product>> { }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult<Service.Models.Product>>
    {
        private readonly ICommonService<Models.Product,Service.Models.Product,int> _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IMapper mapper, ICommonService<Models.Product, Service.Models.Product, int> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CommandResult<Service.Models.Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var data=_mapper.Map<Models.Product>(request.Product);
            var returnData= await _productRepository.AddAsync(data);

            if (returnData is not null and { Id: var id } && id > 0)
            {
                return new CommandResult<Service.Models.Product>(returnData,CommandResultTypeEnum.Created);
            }
            return new CommandResult<Service.Models.Product>(null, CommandResultTypeEnum.UnprocessableEntity);
        }
    }


    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(X=>X.Product).NotNull();
            RuleFor(X=>X.Product.Id).Empty();
            RuleFor(X=>X.Product.ProductName).NotEmpty();
            RuleFor(X => X.Product.ProductColor).NotEmpty();
            RuleFor(X => X.Product.ProductDescription).NotEmpty();
        }
    }
}
