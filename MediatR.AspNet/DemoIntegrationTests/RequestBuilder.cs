using System;
using System.Collections.Generic;
using Bogus;
using Demo.Product.Commands.PostProduct;
using Demo.Product.Commands.PutProduct;

namespace DemoIntegrationTests {
	public static class RequestBuilder {
		private static List<int> _existingIds;
		private static Random _random;
		static RequestBuilder() {
			_existingIds = new List<int>();
			for (int i = 1; i < 11; i++) {
				_existingIds.Add(i);
			}
			_random = new Random();
		}

		public static int CreateExistingId() {
			var id = 0;
			while (id <= 0) {
				id = _random.Next(11);
			}
			return id;
		}

		public static int CreateNotExistingId() {
			var id = 1;
			while (!_existingIds.Contains(id)) {
				id = _random.Next(int.MaxValue);
			}
			_existingIds.Add(id);
			
			return id;
		}

		public static CreateProductCommand CreateProductCommand() {
			var fakerCreateProductCommand = new Faker<CreateProductCommand>()
			                   .RuleFor(a => a.Id, CreateNotExistingId)
			                   .RuleFor(a => a.Name, f => f.Lorem.Word());
			return fakerCreateProductCommand.Generate();
		}

		public static UpdateProductCommand UpdateProductCommand() {
			var fakerUpdateProductCommand = new Faker<UpdateProductCommand>()
			                   .RuleFor(a => a.OldProductId, CreateExistingId)
			                   .RuleFor(a => a.Name, f => f.Lorem.Word())
			                   .RuleFor(a => a.Id, CreateNotExistingId);
			return fakerUpdateProductCommand.Generate();
		}
	}
}