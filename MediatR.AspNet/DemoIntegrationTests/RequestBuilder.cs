using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bogus;
using Demo;
using Demo.Product;
using Demo.Product.Commands.PostProduct;
using Demo.Product.Commands.PutProduct;

namespace DemoIntegrationTests {
	public static class RequestBuilder {
		private static List<Product> _products;
		private static int _id = 20;
		private static Random _random;

		static RequestBuilder() {
			_products = ProductsFactory.Products.ToList();
			_random = new Random();
		}

		public static int CreateExistingId() {
			var index = 0;
			while (index <= 0) {
				index = _random.Next(_products.Count);
			}

			return _products[index].Id;
		}

		public static int CreateNotExistingId() {
			var id = _id;
			_id++;

			return id;
		}

		public static CreateProductCommand CreateCorrectCreateProductCommand() {
			var fakerCreateProductCommand = new Faker<CreateProductCommand>()
			                                .RuleFor(a => a.Id, CreateNotExistingId)
			                                .RuleFor(a => a.Name, f => f.Lorem.Word());
			return fakerCreateProductCommand.Generate();
		}
		
		public static CreateProductCommand CreateIncorrectCreateProductCommand() {
			var fakerCreateProductCommand = new Faker<CreateProductCommand>()
			                                .RuleFor(a => a.Id, CreateExistingId)
			                                .RuleFor(a => a.Name, f => f.Lorem.Word());
			return fakerCreateProductCommand.Generate();
		}
		public static UpdateProductCommand CreateUpdateProductCommand() {
			var fakerUpdateProductCommand = new Faker<UpdateProductCommand>()
			                                .RuleFor(a => a.Name, f => f.Lorem.Word())
			                                .RuleFor(a => a.Id, CreateNotExistingId);
			return fakerUpdateProductCommand.Generate();
		}
	}
}