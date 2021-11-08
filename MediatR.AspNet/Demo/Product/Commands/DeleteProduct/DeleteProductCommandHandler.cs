using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;

namespace Demo.Product.Commands.DeleteProduct {
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDto> {
		private readonly List<Product> _products;
		private readonly IMapper _mapper;

		public DeleteProductCommandHandler(IMapper mapper) {
			_products = ProductsFactory.Products.ToList();
			_mapper = mapper;
		}

		public Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken) {
			var entity = _products.FirstOrDefault(a => a.Id == request.Id);
			if (entity == null) {
				throw new DeleteNotAllowedException(typeof(Product), request.Id.ToString());
			}

			_products.Remove(entity);

			return Task.FromResult(_mapper.Map<ProductDto>(entity));
		}
	}
}