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
    public class ProductController : ControllerBase {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get() {
            var query = new GetProductsQuery();
            var products = _mediator.Send(query);
            return Ok(products.Result);
        }
    }
}