using MediatR.AspNet;

namespace Demo.Product.Queries.GetProducts;

public class GetProductsQuery : IQuery<IEnumerable<ProductDto>> { }