using System;

namespace MediatR.AspNet.Exceptions {
	public class NotFoundException : Exception {
		public NotFoundException() : base("Entity not found") { }
		public NotFoundException(Type entityType) : base($"{entityType.Name} not found") { }
		public NotFoundException(Type entityType, string id) : base($"{entityType.Name} not found with id {id}") { }
		public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
		public NotFoundException(string message) : base(message) { }
	}
}