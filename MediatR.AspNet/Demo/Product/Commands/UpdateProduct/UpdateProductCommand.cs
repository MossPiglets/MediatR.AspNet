using System.Text.Json.Serialization;
using MediatR.AspNet;

namespace Demo.Product.Commands.UpdateProduct {
	public class UpdateProductCommand : ICommand<ProductDto> {
		[JsonIgnore]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}