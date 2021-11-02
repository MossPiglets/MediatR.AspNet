using System.Collections.Generic;
using MediatR.AspNet;

namespace Demo.Product.Queries.GetProducts {
    public class GetProductsQuery : IQuery<List<ProductDto>> { }
}