using System;

namespace MediatR.AspNet {
    public abstract class BaseApplicationException : Exception {
        public string Code;
        public int Status;
        public string Message;

        public BaseApplicationException(string code, int status, string message) {
            Code = code;
            Status = status;
            Message = message;
        }

        public ApplicationProblemDetails ToProblemDetails() {
            return new ApplicationProblemDetails {
                Code = Code,
                Status = Status,
                Message = Message
            };
        }
    }
}
