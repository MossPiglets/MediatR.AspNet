using FluentAssertions;
using MediatR.AspNet.Exceptions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests;

public class ExistsExceptionTests {
    [Test]
    public void ShouldBeException() {
        // Arrange
        // Act
        // Assert
        typeof(ExistsException).Should().BeAssignableTo(typeof(BaseApplicationException));
    }

    [Test]
    public void NoArguments_ShouldReturnExceptionWithBaseMessage() {
        // Arrange
        // Act
        var exception = new ExistsException();
        // Assert
        exception.Message.Should().Be("Entity already exists");
        exception.Code.Should().Be("Exists");
        exception.Status.Should().Be(StatusCodes.Status409Conflict);
    }

    [Test]
    public void EntityType_ShouldReturnExceptionWithEntityType() {
        // Arrange
        var type = typeof(string);
        // Act
        var exception = new ExistsException(type);
        // Assert
        exception.Message.Should().Be($"{type.Name} already exists");
        exception.Code.Should().Be("Exists");
        exception.Status.Should().Be(StatusCodes.Status409Conflict);
    }
    [Test]
    public void EntityTypeAndId_ShouldReturnExceptionWithEntityTypeAndId() {
        // Arrange
        var type = typeof(string);
        var id = "000";
        // Act
        var exception = new ExistsException(type, id);
        // Assert
        exception.Message.Should().Be($"{type.Name} with id {id} already exists");
        exception.Code.Should().Be("Exists");
        exception.Status.Should().Be(StatusCodes.Status409Conflict);
    }
        
    [Test]
    public void Message_ShouldReturnExceptionWithMessage() {
        // Arrange
        var message = "test";
        // Act
        var exception = new ExistsException(message);
        // Assert
        exception.Message.Should().Be(message);
        exception.Code.Should().Be("Exists");
        exception.Status.Should().Be(StatusCodes.Status409Conflict);
    }
}