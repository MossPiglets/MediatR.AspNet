using FluentAssertions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests {
	public class CommandTests {
		[Test]
		public void CommandShouldImplementedIRequest() {
			// Arrange
			// Act
			// Assert
			typeof(IRequest<TestClass>).IsAssignableFrom(typeof(ICommand<TestClass>)).Should().BeTrue();
		}
	}
}