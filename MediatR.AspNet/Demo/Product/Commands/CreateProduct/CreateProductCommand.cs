using MediatR.AspNet;

namespace Demo.Product.Commands.PostProduct {
	public class CreateProductCommand : ICommand<ProductDto> {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}