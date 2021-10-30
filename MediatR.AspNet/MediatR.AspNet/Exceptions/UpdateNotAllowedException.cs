using System;

namespace MediatR.AspNet.Exceptions {
    public class UpdateNotAllowedException : Exception {
        public UpdateNotAllowedException() : base("Cannot update entity") { }
        public UpdateNotAllowedException(Type entityType) : base($"Cannot update {entityType.Name}") { }

        public UpdateNotAllowedException(Type entityType, string id) : base(
            $"Cannot update {entityType.Name} with id {id}") { }

        public UpdateNotAllowedException(string message, Exception innerException) : base(message, innerException) { }
        public UpdateNotAllowedException(string message) : base(message) { }
    }
}