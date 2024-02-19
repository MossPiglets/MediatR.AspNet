using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
	public class NotFoundException : BaseApplicationException {
		public NotFoundException() : base("NotFound", StatusCodes.Status404NotFound, "Entity not found") { }
		public NotFoundException(Type entityType) : base("NotFound", StatusCodes.Status404NotFound, $"{entityType.Name} not found") { }
		public NotFoundException(Type entityType, string id) : base("NotFound", StatusCodes.Status404NotFound, $"{entityType.Name} not found with id {id}") { }
		public NotFoundException(string message) : base("NotFound", StatusCodes.Status404NotFound, message) { }
	}
}
