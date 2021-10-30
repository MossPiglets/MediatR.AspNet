using MediatR.AspNet.Exceptions;
using NUnit.Framework;

namespace MediatR.AspNet.Tests.FiltersTests {
    public class CustomExceptionFilterTests {
        [Test]
        public void NotFoundException_ShouldReturnNotFound() {
            // Arrange 
            var exception = new NotFoundException();
            
        }
    }
}