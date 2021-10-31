using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class OperationNotAllowedExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(OperationNotAllowedException).Should().BeAssignableTo(typeof(Exception));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new OperationNotAllowedException();
            // Assert
            exception.Message.Should().Be("Cannot make operation on entity");
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new OperationNotAllowedException(type);
            // Assert
            exception.Message.Should().Be($"Cannot make operation on {type.Name}");
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
        }

        [Test]
        public void MessageAndInnerException_ShouldReturnExceptionWithMessageAndInnerException() {
            // Arrange
            var innerException = new ArgumentException();
            var message = "test";
            // Act
            var exception = new OperationNotAllowedException(message, innerException);
            // Assert
            exception.Message.Should().Be(message);
            exception.InnerException.Should().Be(innerException);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new OperationNotAllowedException(message);
            // Assert
            exception.Message.Should().Be(message);
        }
    }
}