using System.Collections.Generic;
using Bogus;
using Microsoft.AspNetCore.Authentication;

namespace Demo {
    public static class ProductsFactory {
        public static IEnumerable<Product.Product> Products { get; set; }
        static ProductsFactory() {
            var productId = 0;
            var fakerProduct = new Faker<Product.Product>()
                .RuleFor(a => a.Id, f => productId++)
                .RuleFor(a => a.Name, f => f.Lorem.Word());
            Products = fakerProduct.Generate(10);
        }
    }
}