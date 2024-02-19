using System;
using System.Net;
using System.Threading.Tasks;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MediatR.AspNet {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _request;
        

        public ExceptionMiddleware(RequestDelegate request) {
            _request = request;
        }

        public async Task InvokeAsynce(HttpContext context) {
            try {
                await _request(context);
            }
            catch (NotFoundException e) {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                var error = e.Message;
                await context.Response.WriteAsync(error);
            }
        }
    }
}
