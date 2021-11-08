using System.Collections.Generic;
using Bogus;

namespace Demo {
    public static class ProductsFactory {
        public static IEnumerable<Product.Product> Products { get; set; }
        static ProductsFactory() {
            var fakerProduct = new Faker<Product.Product>()
                .RuleFor(a => a.Id, f => f.IndexFaker)
                .RuleFor(a => a.Name, f => f.Random.Word());
            Products = fakerProduct.Generate(10);
        }
    }
}