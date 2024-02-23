using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Queries.GetProductById {
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ProductDto> {
        private readonly List<Product> _products = ProductsFactory.Products.ToList();

        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
            var productEntity = _products.FirstOrDefault(a => a.Id == request.Id);
            if (productEntity == null) {
                throw new NotFoundException(typeof(Product), request.Id.ToString());
            }

            var mappedProductEntity = productEntity.ToDto();
            return Task.FromResult(mappedProductEntity);
        }
    }
}
