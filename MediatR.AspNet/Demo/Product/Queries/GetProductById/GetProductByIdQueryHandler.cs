using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Queries.GetProductById {
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ProductDto> {
        private readonly List<Product> _products;
        private readonly IMapper _mapper;
        
        public GetProductByIdQueryHandler(IMapper mapper) {
            _products = ProductsFactory.Products.ToList();
            _mapper = mapper;
        }
        
        public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
            var productEntity = _products.FirstOrDefault(a => a.Id == request.Id);
            if (productEntity == null) {
                throw new NotFoundException(typeof(Product), request.Id.ToString());
            }

            var mappedProductEntity = _mapper.Map<ProductDto>(productEntity);
            return Task.FromResult(mappedProductEntity);
        }
    }
}