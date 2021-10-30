using System;

namespace MediatR.AspNet.Exceptions {
    public class OperationNotAllowedException : Exception {
        public OperationNotAllowedException() : base("Cannot make operation on entity") { }
        public OperationNotAllowedException(Type entityType) : base($"Cannot make operation on {entityType.Name}") { }

        public OperationNotAllowedException(Type entityType, string id) : base(
            $"Cannot make operation on {entityType.Name} with id {id}") { }

        public OperationNotAllowedException(string message, Exception innerException) : base(message, innerException) { }
        public OperationNotAllowedException(string message) : base(message) { }
    }
}