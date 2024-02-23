using MediatR;

namespace Demo.Product.Queries.GetProducts {
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>> {
        private readonly List<Product> _products = ProductsFactory.Products.ToList();

        public Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
            var productsEntities = _products.Select(a => a.ToDto());
            return Task.FromResult(productsEntities);
        }
    }
}
