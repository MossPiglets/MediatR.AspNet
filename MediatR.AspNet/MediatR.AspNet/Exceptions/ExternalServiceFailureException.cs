using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class ExternalServiceFailureException : BaseApplicationException {
        public ExternalServiceFailureException() : base("ExternalServiceFailure", StatusCodes.Status502BadGateway, "External service failed") { }
        public ExternalServiceFailureException(string message) : base("ExternalServiceFailure", StatusCodes.Status502BadGateway, message) { }
    }
}
