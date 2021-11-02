using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Demo.Product.Queries.GetProducts {
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>> {
        private readonly List<ProductModel>;
        public GetProductsQueryHandler() {
            
        }

        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException();
        }
    }
}