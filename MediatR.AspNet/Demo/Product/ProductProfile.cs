using AutoMapper;
using Demo.Product.Commands.PostProduct;
using Demo.Product.Commands.PutProduct;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Product {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}