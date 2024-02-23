using MediatR.AspNet;

namespace DemoOld.Product.Commands.CreateProduct {
	public class CreateProductCommand : ICommand<ProductDto> {
		public string Name { get; set; }
	}
}