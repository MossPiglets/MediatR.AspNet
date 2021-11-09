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
		private ProductGenerator _generator = new ProductGenerator();

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
		public async Task GetProducts_ShouldReturnProducts() {
			// Arrange
			var expectedProducts = ProductsFactory.Products;
			//Act
			var response = await _client.GetAsync("Products");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
			// Assert
			products.Should().NotBeEmpty();
			products.Should().BeEquivalentTo(expectedProducts);
		}
		[Test]
		public async Task GetProductById_ExistingId_ShouldReturnProduct() {
			// Arrange
			var expectedProduct = ProductsFactory.Products.First();
			//Act
			var response = await _client.GetAsync($"Products/{expectedProduct.Id}");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Id.Should().Be(expectedProduct.Id);
			product.Name.Should().Be(expectedProduct.Name);
		}
		[Test]
		public async Task GetProductById_NotExistingId_ShouldReturnNotFound() {
			// Arrange
			var notExistingId = int.MaxValue;
			//Act
			var response = await _client.GetAsync($"Products/{notExistingId}");
			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}
		[Test]
		public async Task PostProduct_CorrectId_ShouldReturnProduct() {
			// Arrange
			var createProductCommand = _generator.CreateCreateProductCommand();
			//Act
			var response = await _client.PostAsJsonAsync("Products", createProductCommand);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Name.Should().Be(createProductCommand.Name);
		}
		
		[Test]
		public async Task PutProduct_CorrectId_ShouldReturnProduct() {
			// Arrange
			var updateProductCommand = _generator.CreateUpdateProductCommand();
			var id = ProductsFactory.Products.First().Id;
			//Act
			var response = await _client.PutAsJsonAsync($"Products/{id}", updateProductCommand);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Id.Should().Be(id);
			product.Name.Should().Be(updateProductCommand.Name);
		}
		[Test]
		public async Task PutProduct_NotExistingId_ShouldReturnNotFound() {
			// Arrange
			var updateProductCommand = _generator.CreateUpdateProductCommand();
			var id = int.MaxValue;
			//Act
			var response = await _client.PutAsJsonAsync($"Products/{id}", updateProductCommand);
			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.NotFound);
		}
		[Test]
		public async Task DeleteProduct_CorrectId_ShouldReturnProduct() {
			// Arrange
			var expectedProduct = ProductsFactory.Products.Skip(1).First();
			var id = expectedProduct.Id;
			//Act
			var response = await _client.DeleteAsync($"Products/{id}");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var product = await response.Content.ReadFromJsonAsync<ProductDto>();
			// Assert
			product.Should().NotBeNull();
			product.Id.Should().Be(expectedProduct.Id);
			product.Name.Should().Be(expectedProduct.Name);
		}
		[Test]
		public async Task DeleteProduct_NotExistingId_ShouldReturnBadRequest() {
			// Arrange
			var id = int.MaxValue;
			//Act
			var response = await _client.DeleteAsync($"Products/{id}");
			// Assert
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}
	}
}