using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Commands.PutProduct {
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto> {
		private readonly List<Product> _products;
		private readonly IMapper _mapper;

		public UpdateProductCommandHandler(IMapper mapper) {
			_products = ProductsFactory.Products.ToList();
			_mapper = mapper;
		}

		public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken) {
			var entity = _products.FirstOrDefault(a => a.Id == request.Id);
			if (entity == null) {
				throw new UpdateNotAllowedException(typeof(Product), request.Id.ToString());
			}
			var product = _mapper.Map<Product>(request);
			_products.Remove(entity);
			_products.Add(product);
			
			return Task.FromResult(_mapper.Map<ProductDto>(product));
		}
	}
}