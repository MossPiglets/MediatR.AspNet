using MediatR;

namespace Demo.Product.Commands.CreateProduct {
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto> {
		private readonly List<Product> _products = ProductsFactory.Products.ToList();

		public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
			var product = new Product {
				Name = request.Name
			};
			product.Id = _products.Last().Id + 1;
			_products.Add(product);
			
			return Task.FromResult(product.ToDto());
		}
	}
}
