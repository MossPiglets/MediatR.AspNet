using FluentAssertions;
using MediatR.AspNet.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NUnit.Framework;

namespace MediatR.AspNet.Tests {
    public class FiltersExtensionsTests {
        [Test]
        public void HasCustomExceptionsFilter() {
            // Arrange
            var filterCollection = new FilterCollection();
            // Act 
            filterCollection.AddMediatrExceptions();
            // Assert
            filterCollection.Should().HaveCount(1);
            filterCollection[0].As<TypeFilterAttribute>().ImplementationType.Should().Be(typeof(CustomExceptionFilter));
        }
    }
}