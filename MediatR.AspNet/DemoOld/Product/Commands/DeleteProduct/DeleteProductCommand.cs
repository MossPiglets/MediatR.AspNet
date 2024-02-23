using MediatR.AspNet;

namespace DemoOld.Product.Commands.DeleteProduct {
	public class DeleteProductCommand : ICommand<ProductDto> {
		public int Id { get; set; }
	}
}