using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using MediatR.AspNet.Filters;
using MediatR.AspNet.Tests.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.FiltersTests {
    public class CustomExceptionFilterTests {
        [Test]
        public void NotFoundException_ShouldReturnNotFound() {
            // Arrange 
            var exception = new NotFoundException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.NotFound, "Entity not found");
        }

        [Test]
        public void DeleteNotAllowedException_ShouldReturnMethodNotAllowed() {
            // Arrange 
            var exception = new DeleteNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.MethodNotAllowed, "Cannot delete entity");
        }

        [Test]
        public void OperationNotAllowedException_ShouldReturnForbidden() {
            // Arrange 
            var exception = new OperationNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Forbidden, "Cannot make operation on entity");
        }

        [Test]
        public void ExistsException_ShouldReturnConflict() {
            // Arrange 
            var exception = new ExistsException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict, "Entity already exists");
        }

        [Test]
        public void UpdateNotAllowedException_ShouldReturnConflict() {
            // Arrange 
            var exception = new UpdateNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict, "Cannot update entity");
        }

        [Test]
        public void NotCustomException_ShouldReturnInternalServerError() {
            // Arrange 
            var exception = new NullReferenceException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should()
                .Be((int) HttpStatusCode.InternalServerError, "Object reference not set to an instance of an object");
        }
    }
}