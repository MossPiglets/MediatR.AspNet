using System;

namespace MediatR.AspNet.Exceptions {
	public class NotFoundExceptions : Exception {
		public NotFoundExceptions(string id) : base($"Entity with id {id} do not found") {}
	}
}