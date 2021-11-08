using System;
using FluentAssertions;
using MediatR.AspNet.Exceptions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class NotFoundExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(NotFoundException).Should().BeAssignableTo(typeof(Exception));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new NotFoundException();
            // Assert
            exception.Message.Should().Be("Entity not found");
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new NotFoundException(type);
            // Assert
            exception.Message.Should().Be($"{type.Name} not found");
        }
        [Test]
        public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
            // Arrange
            var type = typeof(string);
            var id = "000";
            // Act
            var exception = new NotFoundException(type, id);
            // Assert
            exception.Message.Should().Be($"{type.Name} not found with id {id}");
        }
        [Test]
        public void MessageAndInnerException_ShouldReturnExceptionWithMessageAndInnerException() {
            // Arrange
            var innerException = new ArgumentException();
            var message = "test";
            // Act
            var exception = new NotFoundException(message, innerException);
            // Assert
            exception.Message.Should().Be(message);
            exception.InnerException.Should().Be(innerException);
        }
        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new NotFoundException(message);
            // Assert
            exception.Message.Should().Be(message);
        }
    }
}