using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace DemoOld.Product.Queries.GetProducts {
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>> {
        private readonly List<Product> _products;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IMapper mapper) {
            _products = ProductsFactory.Products.ToList();
            _mapper = mapper;
        }

        public Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
            var productsEntities = _products.Select(a => _mapper.Map<ProductDto>(a));
            return Task.FromResult(productsEntities);
        }
    }
}