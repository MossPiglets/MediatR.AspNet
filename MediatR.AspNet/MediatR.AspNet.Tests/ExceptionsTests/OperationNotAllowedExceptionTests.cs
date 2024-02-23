using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class OperationNotAllowedExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(OperationNotAllowedException).Should().BeAssignableTo(typeof(BaseApplicationException));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new OperationNotAllowedException();
            // Assert
            exception.Message.Should().Be("Cannot make operation on entity");
            exception.Code.Should().Be("OperationNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status403Forbidden);
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new OperationNotAllowedException(type);
            // Assert
            exception.Message.Should().Be($"Cannot make operation on {type.Name}");
            exception.Code.Should().Be("OperationNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status403Forbidden);
        }

        [Test]
        public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
            // Arrange
            var type = typeof(string);
            var id = "000";
            // Act
            var exception = new OperationNotAllowedException(type, id);
            // Assert
            exception.Message.Should().Be($"Cannot make operation on {type.Name} with id {id}");
            exception.Code.Should().Be("OperationNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status403Forbidden);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new OperationNotAllowedException(message);
            // Assert
            exception.Message.Should().Be(message);
            exception.Code.Should().Be("OperationNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status403Forbidden);
        }
    }
}
