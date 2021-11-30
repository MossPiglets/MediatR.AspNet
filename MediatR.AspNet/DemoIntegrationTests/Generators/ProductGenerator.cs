using Bogus;
using Demo.Product.Commands.CreateProduct;
using Demo.Product.Commands.UpdateProduct;

namespace DemoIntegrationTests.Generators {
	public class ProductGenerator {
		public CreateProductCommand CreateCreateProductCommand() {
			return new Faker<CreateProductCommand>()
				.RuleFor(a => a.Name, f => f.Random.Word());
		}

		public UpdateProductCommand CreateUpdateProductCommand() {
			return new Faker<UpdateProductCommand>()
				.RuleFor(a => a.Name, f => f.Random.Word());
		}
	}
}