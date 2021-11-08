using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Demo;
using Demo.Product;
using Demo.Product.Commands.CreateProduct;
using Demo.Product.Commands.UpdateProduct;

namespace DemoIntegrationTests {
	public class ProductGenerator {
		private readonly List<Product> _products;
		private readonly Random _random;

		public ProductGenerator() {
			_products = ProductsFactory.Products.ToList();
			_random = new Random();
		}

		public int CreateExistingId() {
			var index = _random.Next(_products.Count);

			return _products[index].Id;
		}

		public int CreateNotExistingId() {
			return int.MaxValue;
		}

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