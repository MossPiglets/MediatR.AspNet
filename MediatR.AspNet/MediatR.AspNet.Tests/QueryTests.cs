using FluentAssertions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests;

public class QueryTests {
    [Test]
    public void GenericQuery_ShouldImplementedIRequest() {
        // Arrange
        // Act
        // Assert
        typeof(IQuery<>).Should().BeAssignableTo(typeof(IRequest<>));
    }
    [Test]
    public void DefaultQuery_ShouldImplementedIRequest() {
        // Arrange
        // Act
        // Assert
        typeof(IQuery).Should().BeAssignableTo(typeof(IRequest));
    }
}