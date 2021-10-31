using System;
using System.Collections.Generic;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using MediatR.AspNet.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.FiltersTests {
    public class CustomExceptionFilterTests {
        [Test]
        public void NotFoundException_ShouldReturnNotFound() {
            // Arrange 
            var exception = new NotFoundException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be(404, "Entity not found");
        }

        [Test]
        public void DeleteNotAllowedException_ShouldReturnMethodNotAllowed() {
            // Arrange 
            var exception = new DeleteNotAllowedException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be(405, "Cannot delete entity");
        }

        [Test]
        public void OperationNotAllowedException_ShouldReturnForbidden() {
            // Arrange 
            var exception = new OperationNotAllowedException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be(403, "Cannot make operation on entity");
        }

        [Test]
        public void ExistsException_ShouldReturnConflict() {
            // Arrange 
            var exception = new ExistsException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be(409, "Entity already exists");
        }

        [Test]
        public void UpdateNotAllowedException_ShouldReturnConflict() {
            // Arrange 
            var exception = new UpdateNotAllowedException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be(409, "Cannot update entity");
        }

        [Test]
        public void NotCustomException_ShouldReturnInternalServerError() {
            // Arrange 
            var exception = new NullReferenceException();
            var actionContext = new ActionContext() {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should()
                .Be(500, "Object reference not set to an instance of an object");
        }
    }
}