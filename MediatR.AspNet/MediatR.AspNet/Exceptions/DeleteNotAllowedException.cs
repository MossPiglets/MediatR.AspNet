using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class DeleteNotAllowedException : BaseApplicationException {
        public DeleteNotAllowedException() : base("DeleteNotAllowed",StatusCodes.Status400BadRequest, "Cannot delete entity") { }
        public DeleteNotAllowedException(Type entityType) : base("DeleteNotAllowed",StatusCodes.Status400BadRequest,$"Cannot delete {entityType.Name}") { }
        public DeleteNotAllowedException(Type entityType, string id) : base(
            "DeleteNotAllowed",StatusCodes.Status400BadRequest,
            $"Cannot delete {entityType.Name} with id {id}") { }
        public DeleteNotAllowedException(string message) : base("DeleteNotAllowed",StatusCodes.Status400BadRequest, message) { }
    }
}
