using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MediatR.AspNet {
    public class ApplicationExceptionMiddleware: IMiddleware {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
            try {
                await next(context);
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

