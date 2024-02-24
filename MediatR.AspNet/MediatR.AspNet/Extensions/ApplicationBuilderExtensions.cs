using Microsoft.AspNetCore.Builder;

namespace MediatR.AspNet.Extensions {
    public static class ApplicationBuilderExtensions {
        public static void UseApplicationExceptions(this IApplicationBuilder builder ) {
            builder.UseMiddleware<ApplicationExceptionMiddleware>();
        }
    }
}
