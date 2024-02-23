using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoOld.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommandHandler : IRequestHandler<SendFeedbackCommand> {
        public Task<Unit> Handle(SendFeedbackCommand request, CancellationToken cancellationToken) {
            return Unit.Task;
        }
    }
}