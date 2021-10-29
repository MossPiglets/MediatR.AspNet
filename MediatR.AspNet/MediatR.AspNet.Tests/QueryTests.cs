using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;

namespace MediatR.AspNet.Tests {
    public class QueryTests {
        [Test]
        public void QueryShouldImplementedIRequest() {
            // Arrange
            // Act
            // Assert
            typeof(IQuery<>).Should().BeAssignableTo(typeof(IRequest<>));
        }
    }
}