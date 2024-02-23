using AutoMapper;
using DemoOld.Product.Commands.CreateProduct;
using DemoOld.Product.Commands.UpdateProduct;

namespace DemoOld.Product {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}