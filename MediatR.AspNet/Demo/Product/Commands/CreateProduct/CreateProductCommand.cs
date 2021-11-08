using MediatR.AspNet;

namespace Demo.Product.Commands.CreateProduct {
	public class CreateProductCommand : ICommand<ProductDto> {
		public string Name { get; set; }
	}
}