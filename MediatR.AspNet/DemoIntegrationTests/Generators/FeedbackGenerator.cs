using Bogus;
using Demo.Feedback.Commands.SendFeedback;

namespace DemoIntegrationTests.Generators;

public class FeedbackGenerator {
    public SendFeedbackCommand CreateSendFeedbackCommand() {
            return new Faker<SendFeedbackCommand>()
                .RuleFor(a => a.EmailContent, f => f.Lorem.Sentences(5)); 
    }
}
