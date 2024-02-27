using Demo.Exceptions;
using MediatR;

namespace Demo.Product.Commands.CustomErrorProduct;

public class CustomErrorProductCommmandHandler : IRequestHandler<CustomErrorProductCommand> {
    public Task Handle(CustomErrorProductCommand request, CancellationToken cancellationToken) {
        throw new MyCustomException();
    }
}
