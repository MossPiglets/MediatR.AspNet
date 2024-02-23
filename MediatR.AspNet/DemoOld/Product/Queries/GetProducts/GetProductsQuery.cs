using System.Collections.Generic;
using MediatR.AspNet;

namespace DemoOld.Product.Queries.GetProducts {
    public class GetProductsQuery : IQuery<IEnumerable<ProductDto>> { }
}