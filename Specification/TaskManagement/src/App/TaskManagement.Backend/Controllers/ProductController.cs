using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Product.Command;
using TaskManagement.Core.Product.Query;
using TaskManagement.Core.Product.Query.GetProductWithPagination;
using TaskManagement.Shared.Common.Models;

namespace TaskManagement.Backend.Controllers
{
    [ApiVersion("2")]
    [ApiVersion("1")]
    public class ProductController : ApiControllerBase
    {
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Service.Models.Product>> Get(int id)
        {
            return await HandleQueryAsync(new GetProductByIdQuery(id));

        }
        [HttpGet("GetAllProducts")]
        
        public async Task<ActionResult<List<Service.Models.Product>>> GetProducts()
        {
            var data = await Mediator.Send(new GetAllProductByQuery());
            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<Service.Models.Product>>> GetProductItemWithPagination([FromQuery] GetProductWithPaginationQuery query)
        {
            return await HandleQueryAsync(query);
        }
        [HttpPost]
        public async Task<ActionResult<Service.Models.Product>> ProductCreate([FromBody] CreateProduct.CreateProductCommand product)
        {
            return await HandleCommandAsync(product);
        }
        [HttpPut("{id:int}")]
        public async Task<Service.Models.Product> ProductUpdate([FromBody] Service.Models.Product product,int id)
        {
            return await Mediator.Send(new UpdateProduct.UpdateProductCommand(product,id));
        }
        [HttpDelete("{id:int}")]
        public async Task<Service.Models.Product> ProductDelete(  int id)
        {
            return await Mediator.Send(new DeleteProduct.DeleteProductCommand (id));
        }

        

    }
    
}
