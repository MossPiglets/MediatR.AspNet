using MediatR.AspNet;

namespace Demo.Product.Commands.DeleteProduct;

public class DeleteProductCommand : ICommand<ProductDto> {
	public int Id { get; set; }
}