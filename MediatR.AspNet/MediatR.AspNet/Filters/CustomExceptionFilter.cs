using System.Net;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace MediatR.AspNet.Filters {
    public sealed class CustomExceptionFilter : ExceptionFilterAttribute {
        private readonly IHostEnvironment _environment;
        public CustomExceptionFilter(IHostEnvironment environment) {
            _environment = environment;
        }
        public override void OnException(ExceptionContext context) {
            HttpStatusCode code;
            var problemDetails = new ProblemDetails();
            switch (context.Exception) {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case DeleteNotAllowedException _:
                    code = HttpStatusCode.BadRequest;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case OperationNotAllowedException _:
                    code = HttpStatusCode.Forbidden;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case ExistsException _ :
                case UpdateNotAllowedException _ :
                    code = HttpStatusCode.Conflict;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case NotAuthorizedException _ :
                    code = HttpStatusCode.Unauthorized;
                    problemDetails.Title = context.Exception.Message;
                    break;
                case ExternalServiceFailureException _ :
                    code = HttpStatusCode.BadGateway;
                    problemDetails.Title = context.Exception.Message;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    if (!_environment.IsProduction()) {
                        problemDetails.Title = context.Exception.Message;
                        problemDetails.Detail = context.Exception.ToString();
                    }
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