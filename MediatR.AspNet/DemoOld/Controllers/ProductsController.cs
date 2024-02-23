using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoOld.Product;
using DemoOld.Product.Commands.CreateProduct;
using DemoOld.Product.Commands.DeleteProduct;
using DemoOld.Product.Commands.ErrorProduct;
using DemoOld.Product.Commands.UpdateProduct;
using DemoOld.Product.Queries.GetProductById;
using DemoOld.Product.Queries.GetProducts;
using MediatR;

namespace DemoOld.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get() {
            var query = new GetProductsQuery();
            return await _mediator.Send(query);
        }
        
        [HttpGet("{id}")]
        public async Task<ProductDto> GetById([FromRoute]int id) {
            var query = new GetProductByIdQuery {
                Id = id
            };
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ProductDto> Post(CreateProductCommand command) {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ProductDto> Put([FromRoute] int id, UpdateProductCommand command) {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ProductDto> Delete([FromRoute] int id) {
            var command = new DeleteProductCommand {
                Id = id
            };
            return await _mediator.Send(command);
        }

        [HttpPost("Exception")]
        public async Task<Unit> PostException() {
            return await _mediator.Send(new ErrorProductCommand());
        }
    }
}