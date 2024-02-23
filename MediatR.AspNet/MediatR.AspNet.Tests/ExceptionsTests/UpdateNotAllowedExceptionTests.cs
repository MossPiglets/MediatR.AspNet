using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests {
    public class UpdateNotAllowedExceptionTests {
        [Test]
        public void ShouldBeException() {
            // Arrange
            // Act
            // Assert
            typeof(UpdateNotAllowedException).Should().BeAssignableTo(typeof(BaseApplicationException));
        }

        [Test]
        public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
            // Arrange
            // Act
            var exception = new UpdateNotAllowedException();
            // Assert
            exception.Message.Should().Be("Cannot update entity");
            exception.Code.Should().Be("UpdateNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status409Conflict);
        }

        [Test]
        public void EntityType_ShouldReturnExceptionWithEntityType() {
            // Arrange
            var type = typeof(string);
            // Act
            var exception = new UpdateNotAllowedException(type);
            // Assert
            exception.Message.Should().Be($"Cannot update {type.Name}");
            exception.Code.Should().Be("UpdateNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status409Conflict);
        }

        [Test]
        public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
            // Arrange
            var type = typeof(string);
            var id = "000";
            // Act
            var exception = new UpdateNotAllowedException(type, id);
            // Assert
            exception.Message.Should().Be($"Cannot update {type.Name} with id {id}");
            exception.Code.Should().Be("UpdateNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status409Conflict);
        }

        [Test]
        public void Message_ShouldReturnExceptionWithMessage() {
            // Arrange
            var message = "test";
            // Act
            var exception = new UpdateNotAllowedException(message);
            // Assert
            exception.Message.Should().Be(message);
            exception.Code.Should().Be("UpdateNotAllowed");
            exception.Status.Should().Be(StatusCodes.Status409Conflict);
        }
    }
}
