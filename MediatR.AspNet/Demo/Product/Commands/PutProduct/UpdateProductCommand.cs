using MediatR.AspNet;
using Newtonsoft.Json;

namespace Demo.Product.Commands.PutProduct {
	public class UpdateProductCommand : ICommand<ProductDto> {
		[JsonIgnore]
		public int Id { get; set; }
		public int OldProductId { get; set; }
		public string Name { get; set; }
	}
}