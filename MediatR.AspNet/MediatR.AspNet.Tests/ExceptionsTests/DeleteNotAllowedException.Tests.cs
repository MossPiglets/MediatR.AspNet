using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class DeleteNotAllowedExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(Exception).IsAssignableFrom(typeof(DeleteNotAllowedException)).Should().BeTrue();
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new DeleteNotAllowedException();
            // Assert
            exception.Message.Should().Be("Cannot delete entity");
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new DeleteNotAllowedException(type);
            // Assert
            exception.Message.Should().Be($"Cannot delete {type.Name}");
        }

        [Test]
        public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
            // Arrange
            var type = typeof(string);
            var id = "000";
            // Act
            var exception = new DeleteNotAllowedException(type, id);
            // Assert
            exception.Message.Should().Be($"Cannot delete {type.Name} with the id {id}");
        }

        [Test]
        public void MessageAndInnerException_ShouldReturnExceptionWithMessageAndInnerException() {
            // Arrange
            var innerException = new ArgumentException();
            var message = "test";
            // Act
            var exception = new DeleteNotAllowedException(message, innerException);
            // Assert
            exception.Message.Should().Be(message);
            exception.InnerException.Should().Be(innerException);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new DeleteNotAllowedException(message);
            // Assert
            exception.Message.Should().Be(message);
        }
    }
}