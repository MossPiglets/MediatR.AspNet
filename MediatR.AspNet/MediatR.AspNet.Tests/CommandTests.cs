using FluentAssertions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests {
	public class CommandTests {
		[Test]
		public void CommandShouldImplementedIRequest() {
			// Arrange
			// Act
			// Assert
			typeof(ICommand<>).Should().BeAssignableTo(typeof(IRequest<>));
		}
	}
}