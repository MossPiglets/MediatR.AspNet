using System;
using System.Net;
using System.Threading.Tasks;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
            catch (BaseApplicationException e) {
                context.Response.StatusCode = e.Status;
                var error = e.ToProblemDetails();
                var json = JsonConvert.SerializeObject(error);
                await context.Response.WriteAsync(json);
            }
        }
    }
}

