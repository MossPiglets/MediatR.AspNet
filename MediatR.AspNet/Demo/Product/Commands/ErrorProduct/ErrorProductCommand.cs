using MediatR;
using MediatR.AspNet;

namespace Demo.Product.Commands.ErrorProduct {
    public class ErrorProductCommand : ICommand, IRequest<Unit> { }
}
