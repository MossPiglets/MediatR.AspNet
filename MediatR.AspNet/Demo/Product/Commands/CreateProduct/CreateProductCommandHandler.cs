using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Commands.PostProduct {
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto> {
		private readonly List<Product> _products;
		private readonly IMapper _mapper;

		public CreateProductCommandHandler(IMapper mapper) {
			_products = ProductsFactory.Products.ToList();
			_mapper = mapper;
		}

		public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
			if (_products.Any(a => a.Id == request.Id)) {
				throw new ExistsException(typeof(Product), request.Id.ToString());
			}

			var product = _mapper.Map<Product>(request);
			// tu jebło
			_products.Add(product);
			
			return Task.FromResult(_mapper.Map<ProductDto>(product));
		}
	}
}