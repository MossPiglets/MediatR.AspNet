using System;

namespace MediatR.AspNet.Exceptions {
    public class ExternalServiceFailureException : Exception {
        public ExternalServiceFailureException() : base("External service failed") { }
        public ExternalServiceFailureException(string message, Exception innerException) : base(message, innerException) { }
        public ExternalServiceFailureException(string message) : base(message) { }
    }
}