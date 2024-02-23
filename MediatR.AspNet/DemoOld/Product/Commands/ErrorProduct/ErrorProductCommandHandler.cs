using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoOld.Product.Commands.ErrorProduct {
    public class ErrorProductCommandHandler : IRequestHandler<ErrorProductCommand, Unit> {
        public Task<Unit> Handle(ErrorProductCommand request, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}