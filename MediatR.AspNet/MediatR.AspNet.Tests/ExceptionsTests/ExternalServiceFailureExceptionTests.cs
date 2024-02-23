using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class ExternalServiceFailureExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(ExternalServiceFailureException).Should().BeAssignableTo(typeof(BaseApplicationException));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new ExternalServiceFailureException();
            // Assert
            exception.Message.Should().Be("External service failed");
            exception.Code.Should().Be("ExternalServiceFailure");
            exception.Status.Should().Be(StatusCodes.Status502BadGateway);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new ExternalServiceFailureException(message);
            // Assert
            exception.Message.Should().Be(message);
            exception.Code.Should().Be("ExternalServiceFailure");
            exception.Status.Should().Be(StatusCodes.Status502BadGateway);
        }
    }
}
