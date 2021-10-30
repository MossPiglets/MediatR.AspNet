using System;

namespace MediatR.AspNet.Exceptions {
    public class ExistsException : Exception {
        public ExistsException() : base("Entity already exists") { }
        public ExistsException(Type entityType) : base($"{entityType.Name} already exists") { }

        public ExistsException(Type entityType, string id) : base(
            $"{entityType.Name} with id {id} already exists") { }

        public ExistsException(string message, Exception innerException) : base(message, innerException) { }

        public ExistsException(string message) : base(message) { }
    }
}