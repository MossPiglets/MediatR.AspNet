using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Product;
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
    }
}