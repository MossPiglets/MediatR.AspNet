using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests;

public class DeleteNotAllowedExceptionTests {
    [Test]
    public void ShouldBeException() {
        // Arrange
        // Act
        // Assert
        typeof(DeleteNotAllowedException).Should().BeAssignableTo(typeof(BaseApplicationException));
    }

    [Test]
    public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
        // Arrange
        // Act
        var exception = new DeleteNotAllowedException();
        // Assert
        exception.Message.Should().Be("Cannot delete entity");
        exception.Status.Should().Be(StatusCodes.Status400BadRequest);
        exception.Code.Should().Be("DeleteNotAllowed");
    }

    [Test]
    public void EntityType_ShouldReturnExceptionWithEntityType() {
        // Arrange
        var type = typeof(string);
        // Act
        var exception = new DeleteNotAllowedException(type);
        // Assert
        exception.Message.Should().Be($"Cannot delete {type.Name}");
        exception.Status.Should().Be(StatusCodes.Status400BadRequest);
        exception.Code.Should().Be("DeleteNotAllowed");
    }

    [Test]
    public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
        // Arrange
        var type = typeof(string);
        var id = "000";
        // Act
        var exception = new DeleteNotAllowedException(type, id);
        // Assert
        exception.Message.Should().Be($"Cannot delete {type.Name} with id {id}");
        exception.Status.Should().Be(StatusCodes.Status400BadRequest);
        exception.Code.Should().Be("DeleteNotAllowed");
    }

    [Test]
    public void Message_ShouldReturnExceptionWithMessage() {
        // Arrange
        var message = "test";
        // Act
        var exception = new DeleteNotAllowedException(message);
        // Assert
        exception.Message.Should().Be(message);
        exception.Status.Should().Be(StatusCodes.Status400BadRequest);
        exception.Code.Should().Be("DeleteNotAllowed");
    }
}