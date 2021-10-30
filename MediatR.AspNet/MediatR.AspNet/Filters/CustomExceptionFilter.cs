using System.Net;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MediatR.AspNet.Filters {
    public sealed class CustomExceptionFilter : ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
            HttpStatusCode code;
            var problemDetails = new ProblemDetails();
            switch (context.Exception) {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case DeleteNotAllowedException ex:
                    code = HttpStatusCode.MethodNotAllowed;
                    problemDetails.Title = ex.Message;
                    break;
                case OperationNotAllowedException _:
                    code = HttpStatusCode.Forbidden;
                    break;
                case ExistsException _:
                case UpdateNotAllowedException _:
                    code = HttpStatusCode.Conflict;
                    problemDetails.Title = context.Exception.Message;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            if (code != HttpStatusCode.InternalServerError) {
                context.ExceptionHandled = true;
            }

            problemDetails.Status = (int) code;
            context.HttpContext.Response.StatusCode = (int) code;
            context.Result = new ObjectResult(problemDetails);
        }
    }
}