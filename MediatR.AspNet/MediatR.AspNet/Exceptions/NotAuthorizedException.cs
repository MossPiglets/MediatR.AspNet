using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class NotAuthorizedException : BaseApplicationException {
        public NotAuthorizedException() : base("NotAuthorized", StatusCodes.Status401Unauthorized, "User is not allowed to access entity") { }
        public NotAuthorizedException(Type entityType) : base("NotAuthorized", StatusCodes.Status401Unauthorized, $"User is not allowed to access {entityType.Name}") { }
        public NotAuthorizedException(Type entityType, string id) : base(
            "NotAuthorized", StatusCodes.Status401Unauthorized, 
            $"User is not allowed to access {entityType.Name} with id {id}") { }
        public NotAuthorizedException(string message) : base("NotAuthorized", StatusCodes.Status401Unauthorized, message) { }
    }
}
