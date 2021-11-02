using MediatR.AspNet.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MediatR.AspNet {
    public static class FiltersExtensions {
        public static void AddMediatrExceptions(this FilterCollection filters ) {
            filters.Add(typeof(CustomExceptionFilter));
        }
    }
}