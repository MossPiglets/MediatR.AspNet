using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class UpdateNotAllowedException : BaseApplicationException {
        public UpdateNotAllowedException() : base("UpdateNotAllowed", StatusCodes.Status409Conflict, "Cannot update entity") { }
        public UpdateNotAllowedException(Type entityType) : base("UpdateNotAllowed", StatusCodes.Status409Conflict, $"Cannot update {entityType.Name}") { }
        public UpdateNotAllowedException(Type entityType, string id) : base(
            "UpdateNotAllowed", StatusCodes.Status409Conflict, 
            $"Cannot update {entityType.Name} with id {id}") { }
        public UpdateNotAllowedException(string message) : base("UpdateNotAllowed", StatusCodes.Status409Conflict, message) { }
    }
}
