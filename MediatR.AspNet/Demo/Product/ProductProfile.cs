using AutoMapper;
using Demo.Product.Commands.CreateProduct;
using Demo.Product.Commands.UpdateProduct;

namespace Demo.Product {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}