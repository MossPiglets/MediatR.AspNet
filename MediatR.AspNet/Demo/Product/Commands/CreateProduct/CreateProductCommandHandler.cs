using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace Demo.Product.Commands.CreateProduct {
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto> {
		private readonly List<Product> _products;
		private readonly IMapper _mapper;

		public CreateProductCommandHandler(IMapper mapper) {
			_products = ProductsFactory.Products.ToList();
			_mapper = mapper;
		}

		public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
			var product = _mapper.Map<Product>(request);
			product.Id = _products.Last().Id + 1;
			_products.Add(product);
			
			return Task.FromResult(_mapper.Map<ProductDto>(product));
		}
	}
}