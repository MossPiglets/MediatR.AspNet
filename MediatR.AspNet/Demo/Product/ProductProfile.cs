using AutoMapper;

namespace Demo.Product {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<ProductModel, ProductDto>().ReverseMap();
        }
    }
}