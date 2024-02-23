using MediatR;

namespace Demo.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommandHandler : IRequestHandler<SendFeedbackCommand> {
        public Task Handle(SendFeedbackCommand request, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}
