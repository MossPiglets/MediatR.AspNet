using MediatR.AspNet;

namespace DemoOld.Product.Queries.GetProductById {
    public class GetProductByIdQuery : IQuery<ProductDto> {
        public int Id { get; set; }
    }
}