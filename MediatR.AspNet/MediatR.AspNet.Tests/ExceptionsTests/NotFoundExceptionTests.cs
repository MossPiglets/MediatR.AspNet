using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class NotFoundExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(NotFoundException).Should().BeAssignableTo(typeof(BaseApplicationException));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new NotFoundException();
            // Assert
            exception.Message.Should().Be("Entity not found");
            exception.Code.Should().Be("NotFound");
            exception.Status.Should().Be(StatusCodes.Status404NotFound);
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new NotFoundException(type);
            // Assert
            exception.Message.Should().Be($"{type.Name} not found");
            exception.Code.Should().Be("NotFound");
            exception.Status.Should().Be(StatusCodes.Status404NotFound);
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
            exception.Code.Should().Be("NotFound");
            exception.Status.Should().Be(StatusCodes.Status404NotFound);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new NotFoundException(message);
            // Assert
            exception.Message.Should().Be(message);
            exception.Code.Should().Be("NotFound");
            exception.Status.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
