using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Castle.Core.Logging;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using MediatR.AspNet.Filters;
using MediatR.AspNet.Tests.Factories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MediatR.AspNet.Tests.FiltersTests {
    public class CustomExceptionFilterTests {
        [Test]
        public void NotFoundException_ShouldReturnNotFound() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new NotFoundException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.NotFound);
        }

        [Test]
        public void DeleteNotAllowedException_ShouldReturnMethodNotAllowed() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new DeleteNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);
        }

        [Test]
        public void OperationNotAllowedException_ShouldReturnForbidden() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new OperationNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Forbidden);
        }

        [Test]
        public void ExistsException_ShouldReturnConflict() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new ExistsException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict);
        }

        [Test]
        public void UpdateNotAllowedException_ShouldReturnConflict() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new UpdateNotAllowedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Conflict);
        }

        [Test]
        public void NotCustomException_DevelopmentEnvironment_ShouldReturnInternalServerError() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exceptionMessage = "Test";
            var exception = new InvalidOperationException(exceptionMessage);
            var exceptionProblemDetails = new ProblemDetails {
                Status = StatusCodes.Status500InternalServerError,
                Title = exceptionMessage,
                Detail = exception.ToString()
            };
            var exceptionProblemResult = new ObjectResult(exceptionProblemDetails);
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should()
                .Be((int) HttpStatusCode.InternalServerError);
            exceptionContext.Result.Should().BeEquivalentTo(exceptionProblemResult);
        }
        [Test]
        public void NotCustomException_ProductionEnvironment_ShouldReturnInternalServerError() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Production);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exceptionMessage = "Test";
            var exception = new InvalidOperationException(exceptionMessage);
            var exceptionProblemDetails = new ProblemDetails {
                Status = StatusCodes.Status500InternalServerError,
                Title = null,
            };
            var exceptionProblemResult = new ObjectResult(exceptionProblemDetails);
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should()
                .Be((int) HttpStatusCode.InternalServerError);
            exceptionContext.Result.Should().BeEquivalentTo(exceptionProblemResult);
        }
        
        [Test]
        public void NotAuthorizedException_ShouldReturnUnauthorized() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new NotAuthorizedException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.Unauthorized);
        }
        [Test]
        public void ExternalServiceFailureException_ShouldReturnUnauthorized() {
            // Arrange 
            var environment = new Mock<IHostEnvironment>();
            environment.Setup(a => a.EnvironmentName).Returns(Environments.Development);
            var mockLogger = new Mock<ILogger<CustomExceptionFilter>>();
            var exception = new ExternalServiceFailureException();
            var actionContext = ActionContextFactory.CreateActionContext();
            var exceptionContext = new ExceptionContext(actionContext, new List<IFilterMetadata>()) {
                Exception = exception
            };
            var filter = new CustomExceptionFilter(environment.Object, mockLogger.Object);

            // Act
            filter.OnException(exceptionContext);

            // Assert
            actionContext.HttpContext.Response.StatusCode.Should().Be((int) HttpStatusCode.BadGateway);
        }
    }
}