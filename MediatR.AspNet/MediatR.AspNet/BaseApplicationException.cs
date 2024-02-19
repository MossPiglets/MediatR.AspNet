using System;

namespace MediatR.AspNet {
    public abstract class BaseApplicationException : Exception {
        private string _code;
        private int _status;
        private string _message;

        public BaseApplicationException(string code, int status, string message) {
            _code = code;
            _status = status;
            _message = message;
        }

        public ApplicationErrorDetails ToProblemDetails() {
            return new ApplicationErrorDetails {
                Code = _code,
                Status = _status,
                Message = _message
            };
        }
    }
}
