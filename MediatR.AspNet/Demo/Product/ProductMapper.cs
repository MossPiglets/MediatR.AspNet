namespace Demo.Product;

public static class ProductMapper {
    public static ProductDto ToDto(this Product product) {
        return new ProductDto {
            Id = product.Id,
            Name = product.Name
        };
    }
}
