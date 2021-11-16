using System;

namespace MediatR.AspNet.Exceptions {
    public class NotAuthorizedException : Exception {
        public NotAuthorizedException() : base("User is not allowed to access entity") { }
        public NotAuthorizedException(Type entityType) : base($"User is not allowed to access {entityType.Name}") { }
        public NotAuthorizedException(Type entityType, string id) : base(
            $"User is not allowed to access {entityType.Name} with {id}") { }
        public NotAuthorizedException(string message, Exception innerException) : base(message, innerException) { }
        public NotAuthorizedException(string message) : base(message) { }
    }
}