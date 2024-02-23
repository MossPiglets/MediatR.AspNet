using System.Threading.Tasks;
using DemoOld.Feedback.Commands.SendFeedback;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoOld.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase {
        private readonly IMediator _mediator;

        public FeedbackController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<Unit> Post(SendFeedbackCommand command) {
            return await _mediator.Send(command);
        }
    }
}