using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Demo.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommandHandler : IRequestHandler<SendFeedbackCommand> {
        public Task<Unit> Handle(SendFeedbackCommand request, CancellationToken cancellationToken) {
            return Unit.Task;
        }
    }
}