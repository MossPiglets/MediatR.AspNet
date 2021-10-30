using System;

namespace MediatR.AspNet.Exceptions {
    public class DeleteNotAllowedException : Exception {
        public DeleteNotAllowedException() : base("Cannot delete entity") { }
        public DeleteNotAllowedException(Type entityType) : base($"Cannot delete {entityType.Name}") { }

        public DeleteNotAllowedException(Type entityType, string id) : base(
            $"Cannot delete {entityType.Name} with id {id}") { }

        public DeleteNotAllowedException(string message, Exception innerException) : base(message, innerException) { }
        public DeleteNotAllowedException(string message) : base(message) { }
    }
}