using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Product;
using Demo.Product.Commands.PostProduct;
using Demo.Product.Queries.GetProductById;
using Demo.Product.Queries.GetProducts;
using MediatR;

namespace Demo.Controllers {
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
        public async Task<ProductDto> GetById(int id) {
            var query = new GetProductByIdQuery {
                Id = id
            };
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<ProductDto> Post(PostProductCommand command) {
            return await _mediator.Send(command);
        }
    }
}