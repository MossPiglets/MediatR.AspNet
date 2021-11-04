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
		public async Task GetProducts_ShouldReturnProductsList() {
			// Arrange
			var productsFromData = ProductsFactory.Products;
			//Act
			var response = await _client.GetAsync("api/Products");
			response.StatusCode.Should().Be(HttpStatusCode.OK);
			var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
			// Assert
			products.Should().NotBeEmpty();
			products.Should().ContainEquivalentOf(productsFromData.ToList());
		}
	}
}