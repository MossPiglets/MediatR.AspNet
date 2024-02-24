using MediatR.AspNet;

namespace Demo.Product.Queries.GetProductById;

public class GetProductByIdQuery : IQuery<ProductDto> {
    public int Id { get; set; }
}