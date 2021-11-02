using System.Collections.Generic;
using Bogus;
using Demo.Product;

namespace Demo {
    public static class ProductsFactory {
        public static List<ProductModel> GetProducts(int numbersOfProducts = 10) {
            var productId = 0;
            var fakerProduct = new Faker<ProductModel>()
                .RuleFor(a => a.Id, f => productId++)
                .RuleFor(a => a.Name, f => f.Lorem.Word());
            return fakerProduct.Generate(numbersOfProducts);
        }
    }
}