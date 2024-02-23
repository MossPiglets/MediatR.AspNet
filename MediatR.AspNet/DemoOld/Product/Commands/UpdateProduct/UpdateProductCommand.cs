using System.Text.Json.Serialization;
using MediatR.AspNet;

namespace DemoOld.Product.Commands.UpdateProduct {
	public class UpdateProductCommand : ICommand<ProductDto> {
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}