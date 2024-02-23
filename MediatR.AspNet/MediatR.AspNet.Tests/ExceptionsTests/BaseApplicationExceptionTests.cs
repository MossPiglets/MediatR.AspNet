using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.ExceptionsTests;

public class BaseApplicationExceptionTests {
    [Test]
    public void ToProblemDetails_ShouldReturnProblemDetails() {
        // Arrange
        var exception = Substitute.For<BaseApplicationException>("Test code", StatusCodes.Status403Forbidden, "Test message");
        
        // Act
        var problemDetails = exception.ToProblemDetails();
        
        // Assert
        problemDetails.Message.Should().Be(exception.Message);
        problemDetails.Code.Should().Be(exception.Code);
        problemDetails.Status.Should().Be(exception.Status);
    }
}
