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
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
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
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
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
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Forbidden);
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
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict);
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
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict);
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
                .Be((int) HttpStatusCode.InternalServerError);
        }
        [Test]
        public void NotAuthorizedException_ShouldReturnUnauthorized() {
            // Arrange 
            var exception = new NotAuthorizedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Unauthorized);
        }
        [Test]
        public void ExternalServiceFailureException_ShouldReturnUnauthorized() {
            // Arrange 
            var exception = new ExternalServiceFailureException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter();

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.BadGateway);
        }
    }
}