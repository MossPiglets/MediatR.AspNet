using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class NotAuthorizedExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(NotAuthorizedException).Should().BeAssignableTo(typeof(BaseApplicationException));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new NotAuthorizedException();
            // Assert
            exception.Message.Should().Be("User is not allowed to access entity");
            exception.Code.Should().Be("NotAuthorized");
            exception.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new NotAuthorizedException(type);
            // Assert
            exception.Message.Should().Be($"User is not allowed to access {type.Name}");
            exception.Code.Should().Be("NotAuthorized");
            exception.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }
        [Test]
        public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
            // Arrange
            var type = typeof(string);
            var id = "000";
            // Act
            var exception = new NotAuthorizedException(type, id);
            // Assert
            exception.Message.Should().Be($"User is not allowed to access {type.Name} with id {id}");
            exception.Code.Should().Be("NotAuthorized");
            exception.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new NotAuthorizedException(message);
            // Assert
            exception.Message.Should().Be(message);
            exception.Code.Should().Be("NotAuthorized");
            exception.Status.Should().Be(StatusCodes.Status401Unauthorized);
        }
    }
}
