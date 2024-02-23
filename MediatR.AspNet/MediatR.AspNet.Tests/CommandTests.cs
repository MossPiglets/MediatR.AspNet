using FluentAssertions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests;

public class CommandTests {
	[Test]
	public void GenericCommand_ShouldImplementedIRequest() {
		// Arrange
		// Act
		// Assert
		typeof(ICommand<>).Should().BeAssignableTo(typeof(IRequest<>));
	}
	[Test]
	public void DefaultCommand_ShouldImplementedIRequest() {
		// Arrange
		// Act
		// Assert
		typeof(ICommand).Should().BeAssignableTo(typeof(IRequest));
	}
}