using System;

namespace MediatR.AspNet {
    public abstract class BaseApplicationException : Exception {
        public string Code;
        public int Status;

        public BaseApplicationException(string code, int status, string message) : base(message) {
            Code = code;
            Status = status;
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
