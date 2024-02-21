using FluentAssertions;
using MediatR.AspNet.Filters;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NUnit.Framework;

namespace MediatR.AspNet.Tests {
    public class ApplicationBuilderExtensionsTests {
        [Test]
        public void HasCustomExceptionsFilter() {
            // Arrange
            var filterCollection = new FilterCollection();
            var builder = new ApplicationBuilder();
            // Act 
            builder.UseApplicationExceptions();
            filterCollection.UseApplicationExceptions();
            // Assert
            filterCollection.Should().HaveCount(1);
            filterCollection[0].As<TypeFilterAttribute>().ImplementationType.Should().Be(typeof(CustomExceptionFilter));
        }
    }
}
