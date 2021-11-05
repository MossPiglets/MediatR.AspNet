using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Demo;
using Demo.Product;
using FluentAssertions;
using NUnit.Framework;

namespace DemoIntegrationTests {
	public class ProductControllerIntegrationTests {
		private HttpClient _client;

		[OneTimeSetUp]
		public void Setup() {
			var factory = new DemoWebApplicationFactory();
			_client = factory.CreateClient();
		}

		[OneTimeTearDown]
		public void CleanUp() {
			_client.Dispose();
		}

		[Test]
		public async Task GetProducts_ShouldReturnProductDtosList() {
			// Arrange
			var productsFromData = ProductsFactory.Products.ToList();
			//Act
			var response = await _client.GetAsync("Products");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
			// Assert
			products.Should().NotBeEmpty();
			products.Count.Should().Be(productsFromData.Count());
			for (int i = 0; i < products.Count; i++) {
				products[i].Id.Should().Be(productsFromData[i].Id);
				products[i].Name.Should().Be(productsFromData[i].Name);
			}
		}
		[Test]
		public async Task GetProductById_ExistingId_ShouldReturnProductDto() {
			// Arrange
			var productsFromData = ProductsFactory.Products.ToList();
			var id = RequestBuilder.CreateExistingId();
			var productFromData = productsFromData.First(a => a.Id == id);
			//Act
			var response = await _client.GetAsync($"Products/{id}");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Id.Should().Be(productFromData.Id);
			product.Name.Should().Be(productFromData.Name);
		}
		[Test]
		public async Task GetProductById_NotExistingId_ShouldReturnNotFound() {
			// Arrange
			var id = RequestBuilder.CreateNotExistingId();
			//Act
			var response = await _client.GetAsync($"Products/{id}");
			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}
		[Test]
		public async Task PostProduct_NotExistingId_ShouldReturnProductDto() {
			// Arrange
			var createProductCommand = RequestBuilder.CreateProductCommand();
			//Act
			var response = await _client.PostAsJsonAsync("Products", createProductCommand);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Id.Should().Be(createProductCommand.Id);
			product.Name.Should().Be(createProductCommand.Name);
		}
	}
}