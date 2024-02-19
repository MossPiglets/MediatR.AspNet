using System;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet.Exceptions {
    public class ExistsException : BaseApplicationException {
        public ExistsException() : base("Exists", StatusCodes.Status409Conflict, "Entity already exists") { }
        public ExistsException(Type entityType) : base("Exists", StatusCodes.Status409Conflict, $"{entityType.Name} already exists") { }
        public ExistsException(Type entityType, string id) : base(
            "Exists", StatusCodes.Status409Conflict, 
            $"{entityType.Name} with id {id} already exists") { }
        public ExistsException(string message) : base("Exists", StatusCodes.Status409Conflict, message) { }
    }
}
