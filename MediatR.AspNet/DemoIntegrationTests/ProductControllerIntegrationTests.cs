using System.Net.Http;
using NUnit.Framework;

namespace DemoIntegrationTests
{
    public class ProductControllerIntegrationTests
    {
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
        public void Test1()
        {
            Assert.Pass();
        }
    }
}