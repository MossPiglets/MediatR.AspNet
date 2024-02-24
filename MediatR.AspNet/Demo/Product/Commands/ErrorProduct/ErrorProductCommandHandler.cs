using MediatR;

namespace Demo.Product.Commands.ErrorProduct;

public class ErrorProductCommandHandler : IRequestHandler<ErrorProductCommand> {
    public Task Handle(ErrorProductCommand request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
