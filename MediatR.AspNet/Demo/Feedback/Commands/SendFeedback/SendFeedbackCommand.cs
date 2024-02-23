using MediatR.AspNet;

namespace Demo.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommand : ICommand {
        public string EmailContent { get; set; }
    }
}
