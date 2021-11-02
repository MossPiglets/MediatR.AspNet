using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Demo.Product.Queries.GetProducts {
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>> {
        private readonly List<ProductModel> _products;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IMapper mapper) {
            _products = ProductsFactory.GetProducts();
            _mapper = mapper;
        }

        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
            var productsEntities = _products.Select(a => _mapper.Map<ProductDto>(a))
                .ToList();
            return Task.FromResult(productsEntities);
        }
    }
}