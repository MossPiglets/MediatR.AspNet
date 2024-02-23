using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto> {
	private readonly List<Product> _products = ProductsFactory.Products.ToList();

	public Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken) {
		var entity = _products.FirstOrDefault(a => a.Id == request.Id);
		if (entity == null) {
			throw new DeleteNotAllowedException(typeof(Product), request.Id.ToString());
		}

		_products.Remove(entity);

		return Task.FromResult(entity.ToDto());
	}
}
