using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;

namespace MediatR.AspNet.Tests
{
    public class QueryTests
    {
        [Test]
        public void QueryShouldImplementedIRequest()
        {
            // Arrange
            // Act
            // Assert
            typeof(IRequest<TestClass>).IsAssignableFrom(typeof(IQuery<TestClass>)).Should().BeTrue();
        }
    }
}