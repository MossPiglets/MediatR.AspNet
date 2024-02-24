using Microsoft.Extensions.DependencyInjection;

namespace MediatR.AspNet.Extensions {
    public static class ServiceCollectionExtensions {
        public static void AddApplicationExceptions(this IServiceCollection services) {
            services.AddTransient<ApplicationExceptionMiddleware>();
        }
    }
}
