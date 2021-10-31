using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;

namespace MediatR.AspNet.Tests.Factories {
    public static class ActionContextFactory {
        public static ActionContext CreateActionContext() {
            return new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
        }
    }
}