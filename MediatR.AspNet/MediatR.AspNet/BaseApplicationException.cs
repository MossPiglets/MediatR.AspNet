using System;

namespace MediatR.AspNet {
    public abstract class BaseApplicationException : Exception {
        private string _code;
        public int Status;
        private string _message;

        public BaseApplicationException(string code, int status, string message) {
            _code = code;
            Status = status;
            _message = message;
        }

        public ApplicationErrorDetails ToProblemDetails() {
            return new ApplicationErrorDetails {
                Code = _code,
                Status = Status,
                Message = _message
            };
        }
    }
}
