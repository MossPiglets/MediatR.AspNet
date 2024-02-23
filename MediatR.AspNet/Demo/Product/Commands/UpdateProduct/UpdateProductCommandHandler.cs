using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Commands.UpdateProduct {
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto> {
		private readonly List<Product> _products = ProductsFactory.Products.ToList();

		public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken) {
			var entity = _products.FirstOrDefault(a => a.Id == request.Id);
			if (entity == null) {
				throw new NotFoundException(typeof(Product), request.Id.ToString());
			}

			var product = new Product {
				Id = request.Id,
				Name = request.Name
			};
			_products.Remove(entity);
			_products.Add(product);
			
			return Task.FromResult(product.ToDto());
		}
	}
}
