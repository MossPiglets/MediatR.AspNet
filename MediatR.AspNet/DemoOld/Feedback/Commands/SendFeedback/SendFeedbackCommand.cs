using MediatR.AspNet;

namespace DemoOld.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommand : ICommand {
        public string EmailContent { get; set; }
    }
}