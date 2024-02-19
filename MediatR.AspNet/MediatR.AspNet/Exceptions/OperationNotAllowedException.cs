using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class OperationNotAllowedException : BaseApplicationException {
        public OperationNotAllowedException() : base("OperationNotAllowed", StatusCodes.Status403Forbidden, "Cannot make operation on entity") { }
        public OperationNotAllowedException(Type entityType) : base("OperationNotAllowed", StatusCodes.Status403Forbidden, $"Cannot make operation on {entityType.Name}") { }
        public OperationNotAllowedException(Type entityType, string id) : base(
            "OperationNotAllowed", StatusCodes.Status403Forbidden, 
            $"Cannot make operation on {entityType.Name} with id {id}") { }
        public OperationNotAllowedException(string message) : base("OperationNotAllowed", StatusCodes.Status403Forbidden, message) { }
    }
}
